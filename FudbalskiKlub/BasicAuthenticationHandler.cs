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
        //IKorisniciService _korisniciService;
        //IKorisnikUlogaService _korisnikUlogaService;
        //MiniafkContext _context;

        public BasicAuthenticationHandler(
            //IKorisniciService korisniciService,
            //IKorisnikUlogaService korisnikUlogaService,
            IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            //_korisnikUlogaService = korisnikUlogaService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
            //if (!Request.Headers.ContainsKey("Authorization"))
            //{
            //    return AuthenticateResult.Fail("Missing header");
            //}

            //var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            //var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
            //var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');

            //var username = credentials[0];
            //var password = credentials[1];

            //var user = await _korisnikUlogaService.Login(username, password);

            //if (user == null)
            //{
            //    return AuthenticateResult.Fail("Incorrect username or password");
            //}
            //else
            //{
            //    var getUser = _context.Korisniks.Where(c=>c.KorisnikId==user.KorisnikId);
            //    var getUloga = _context.Ulogas.Where(c=>c.UlogaId==user.UlogaId);

            //    var claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.Name, )
            //        //new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme)
            //    };

            //    foreach (var role in user.KorisnikUlogas)
            //    {
            //        if(role.UlogaId==1)
            //            claims.Add(new Claim(ClaimTypes.Role, "Administracija"));
            //        else if (role.UlogaId == 2)
            //            claims.Add(new Claim(ClaimTypes.Role, "Glavni trener"));
            //        else if (role.UlogaId == 3)
            //            claims.Add(new Claim(ClaimTypes.Role, "Pomoćni trener"));
            //        else
            //            claims.Add(new Claim(ClaimTypes.Role, "Igrač"));
            //    }

            //    var identity = new ClaimsIdentity(claims, Scheme.Name);

            //    var principal = new ClaimsPrincipal(identity);

            //    var ticket = new AuthenticationTicket(principal, Scheme.Name);
            //    return AuthenticateResult.Success(ticket);
            //}
        }
    }
}
