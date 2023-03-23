using GrowthBook;
using System.Net;

namespace FeatureFlaggingDotNet.FeatureFlagging.Domain.FeatureFlagging
{
    public class FeaturesResult
    {
        public HttpStatusCode Status { get; set; }
        public IDictionary<string, Feature>? Features { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
