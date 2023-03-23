using FeatureFlaggingDotNet.FeatureFlagging.Domain.Services;

namespace FeatureFlaggingDotNet.FeatureFlagging.Domain
{
    public class WeatherFactory
    {
        private readonly IServiceProvider serviceProvider;

        public WeatherFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IWeatherOperation WeatherOperation(string userSelection)
        {
            return userSelection.ToLower() switch
            {
                "celsius" => (IWeatherOperation)serviceProvider.GetService(typeof(CelsiusOperations)),
                "fahrenheit" => (IWeatherOperation)serviceProvider.GetService(typeof(FahrenheitOperations)),
                "kelvin" => (IWeatherOperation)serviceProvider.GetService(typeof(KelvinOperations)),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
