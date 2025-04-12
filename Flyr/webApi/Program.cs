using Flyr.Application.Mappings;
using Flyr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Flyr.Infrastructure.Persistence;
using Flyr.Domain.Contracts;
using Flyr.Infrastructure.Repositories;
using Flyr.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FlyrDb");

builder.Services.AddDbContext<FlyrDbContext>(options =>
    options.UseSqlServer(connectionString)); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// para poder que el automaper funcione tuve que instalar una version mas antigua, la 12.0.0
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<JsonDataSeeder>();
builder.Services.AddScoped<JourneyService>();
builder.Services.AddScoped<FlightService>();
builder.Services.AddScoped<TransportService>();

//Repositories 
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();    

//

//app
var app = builder.Build();
app.MapControllers();
var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<JsonDataSeeder>();
await seeder.SeedAsync("../Infraestructure/Data/markets.json");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
