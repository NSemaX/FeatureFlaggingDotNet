using FeatureFlaggingDotNet.FeatureFlagging.Domain.Models;

namespace FeatureFlaggingDotNet.FeatureFlagging.Domain
{
    public interface IWeatherOperation
    {
        IEnumerable<WeatherForecast> GetWeather(string temperatureType);
    }
}
