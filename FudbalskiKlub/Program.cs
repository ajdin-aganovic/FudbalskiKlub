using FudbalskiKlub.Filters;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodiStateMachine;
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


builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialPlatumState>();
builder.Services.AddTransient<DraftPlatumState>();
builder.Services.AddTransient<ActivePlatumState>();

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MiniafkContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(IPlatumService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MiniafkContext>();
    //dataContext.Database1.EnsureCreated();

    var conn = dataContext.Database.GetConnectionString();

    //dataContext.Database1.Migrate();


}

app.Run();
