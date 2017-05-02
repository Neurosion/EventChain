using EventChain.Core.Generation;

namespace EventChain.Monitoring
{
    public interface IMonitor : IEventGenerator
    {
        string Name { get; set; }
        string Description { get; set; }
        void Start();
        void Stop();
    }
}