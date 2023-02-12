using XPandAuthentication.Repositories;
using XPandAuthentication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy(name: "SpaceExpedition",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:8080", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    })
);

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddScoped<JwtService>();

var app = builder.Build();

app.UseCors("SpaceExpedition");

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
