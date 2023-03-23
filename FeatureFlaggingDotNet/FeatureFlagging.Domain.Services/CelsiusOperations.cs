using FeatureFlaggingDotNet.FeatureFlagging.Domain.Models;

namespace FeatureFlaggingDotNet.FeatureFlagging.Domain.Services
{
    public class CelsiusOperations : IWeatherOperation
    {
        public IEnumerable<WeatherForecast> GetWeather(string temperatureType)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Temperature = (Random.Shared.Next(-20, 55)).ToString() + " " + temperatureType,
                Summary = WeatherTypes.Summaries[Random.Shared.Next(WeatherTypes.Summaries.Length)]
            })
            .ToArray();
        }
    }
}
