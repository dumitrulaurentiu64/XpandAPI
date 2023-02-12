using XpandPlanetAPI.Repositories;
using XpandPlanetAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


builder.Services.AddCors(options => options.AddPolicy(name: "SpaceExpedition",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:8080", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    })
);

builder.Services.AddScoped<IPlanetRepository,PlanetRepository>();
builder.Services.AddScoped<ICrewService, CrewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SpaceExpedition");

app.UseAuthorization();

app.MapControllers();

app.Run();
