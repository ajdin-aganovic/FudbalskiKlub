using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Database1;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace FudbalskiKlub
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        IKorisnikService _korisnikService;
        //IKorisnikUlogaService _korisnikUlogaService;
        //MiniafkContext _context;

        public BasicAuthenticationHandler(
            IKorisnikService korisnikService,
            //IKorisnikUlogaService korisnikUlogaService,
            IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _korisnikService = korisnikService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //throw new NotImplementedException();

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing header");
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');

            var username = credentials[0];
            var password = credentials[1];

            var user = await _korisnikService.Login(username, password);

            if (user == null)
            //if (username == null||password==null)
            {
                return AuthenticateResult.Fail("Incorrect username or password");
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Ime ),
                    new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme ),
                    new Claim(ClaimTypes.Role, user.Uloga)
                };



                //foreach(var role in user.KorisnikUlogas)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, role.Uloga.NazivUloge));
                //}



                var identity = new ClaimsIdentity(claims, Scheme.Name);

                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
        }
    }
}
