using EventChain.Core.Configuration;

namespace EventChain.Monitoring.Configuration
{
    public interface IMonitorConfiguration : IConfiguration
    {
        string DisplayName { get; set; }
        string Description { get; set; }
    }
}