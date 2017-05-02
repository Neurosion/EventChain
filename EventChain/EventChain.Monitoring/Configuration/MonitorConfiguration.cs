namespace EventChain.Monitoring.Configuration
{
    public class MonitorConfiguration : IMonitorConfiguration
    {
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}