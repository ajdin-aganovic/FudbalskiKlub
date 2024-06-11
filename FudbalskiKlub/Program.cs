using FudbalskiKlub;
using FudbalskiKlub.Filters;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodiStateMachine;
using FudbalskiKlub.Services.ProizvodStateMachine;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IBolestService, BolestService>();
builder.Services.AddTransient<IClanarinaService, ClanarinaService>();
builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IPlatumService, PlatumService>();
builder.Services.AddTransient<IPozicijaService, PozicijaService>();
builder.Services.AddTransient<IStadionService, StadionService>();
builder.Services.AddTransient<IStatistikaService, StatistikaService>();
builder.Services.AddTransient<ITerminService, TerminService>();
builder.Services.AddTransient<ITransakcijskiRacunService, TransakcijskiRacunService>();
builder.Services.AddTransient<ITreningService, TreningService>();
builder.Services.AddTransient<IUlogaService, UlogaService>();
builder.Services.AddTransient<IKorisnikPozicijaService, KorisnikPozicijaService>();
builder.Services.AddTransient<IProizvodService, ProizvodService>();


builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialPlatumState>();
builder.Services.AddTransient<DraftPlatumState>();
builder.Services.AddTransient<ActivePlatumState>();

builder.Services.AddTransient<BaseProizvodState>();
builder.Services.AddTransient<InitialProizvodState>();
builder.Services.AddTransient<DraftProizvodState>();
builder.Services.AddTransient<ActiveProizvodState>();

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[]{}
    } });

});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MiniafkContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddMapster(typeof(IKorisnikService));
builder.Services.AddMapster();
builder.Services.AddAutoMapper(typeof(IKorisnikService));
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MiniafkContext>();
    //dataContext.Database.EnsureCreated();

    var conn = dataContext.Database.GetConnectionString();

    //dataContext.Database.Migrate();


}

app.Run();
