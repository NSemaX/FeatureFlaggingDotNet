namespace FeatureFlaggingDotNet.FeatureFlagging.Domain.FeatureFlagging
{
    public interface IFeatureFlagging
    {
        public Task<string> GetTemperatureFeature();
    }
}
