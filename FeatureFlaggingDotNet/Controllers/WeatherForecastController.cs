using FeatureFlaggingDotNet.FeatureFlagging.Domain;
using FeatureFlaggingDotNet.FeatureFlagging.Domain.FeatureFlagging;
using FeatureFlaggingDotNet.FeatureFlagging.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlaggingDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFeatureFlagging _featureFlagging;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherFactory _weatherFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFeatureFlagging featureFlagging, WeatherFactory weatherFactory)
        {
            _logger = logger;
            _weatherFactory = weatherFactory;
            _featureFlagging = featureFlagging ?? throw new ArgumentNullException(nameof(featureFlagging));

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get() //Fahrenheit  Celsius  Kelvin
        {
            var temperatureType = "Celsius";
            //var temperatureType= await _featureFlagging.GetTemperatureFeature();
            Console.Write("feature flagged temprature type : {0}", temperatureType);
            return _weatherFactory.WeatherOperation(temperatureType).GetWeather(temperatureType);
        }
    }
}