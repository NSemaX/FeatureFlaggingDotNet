using FeatureFlaggingDotNet.FeatureFlagging.Domain;
using FeatureFlaggingDotNet.FeatureFlagging.Domain.FeatureFlagging;
using FeatureFlaggingDotNet.FeatureFlagging.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFeatureFlagging, FeatureFlagging>();

builder.Services.AddSingleton<WeatherFactory>();

builder.Services.AddSingleton<CelsiusOperations>()
            .AddSingleton<IWeatherOperation, CelsiusOperations>(s => s.GetService<CelsiusOperations>());

builder.Services.AddSingleton<FahrenheitOperations>()
            .AddSingleton<IWeatherOperation, FahrenheitOperations>(s => s.GetService<FahrenheitOperations>());

builder.Services.AddSingleton<KelvinOperations>()
            .AddSingleton<IWeatherOperation, KelvinOperations>(s => s.GetService<KelvinOperations>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
