using GrowthBook;
using Newtonsoft.Json;
using System.Net;

namespace FeatureFlaggingDotNet.FeatureFlagging.Domain.FeatureFlagging
{

    public class FeatureFlagging : IFeatureFlagging
    {
        //https://app.growthbook.io/features
        public async Task<string> GetTemperatureFeature()
        {
            // Fetch feature flags from the GrowthBook API
            var features = new Dictionary<string, Feature> { };

            var url = "https://cdn.growthbook.io/api/features/your-sdk-number";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var featuresResult = JsonConvert.DeserializeObject<FeaturesResult>(content);
                    features = (Dictionary<string, Feature>)featuresResult.Features;
                }
            }

            var context = new Context
            {
                Enabled = true,
                Features = features
            };
            var gb = new GrowthBook.GrowthBook(context);

            var value = gb.GetFeatureValue<string>("temperature-feature", "fallback");

            return value;

        }

    }
}
