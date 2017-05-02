using System.Collections.Generic;
using System.Linq;
using EventChain.Core.Configuration;

namespace EventChain.Monitoring.Configuration
{
    public abstract class MonitorConfigurationDrivenFactory<TDefinition, TMonitor> : ConfigurationDrivenFactory<TDefinition, TMonitor>, IMonitorFactory
        where TMonitor: IMonitor
        where TDefinition: IMonitorConfiguration
    {
        protected override string ConfigExtension => "monitorconfig";

        protected MonitorConfigurationDrivenFactory(string configPath, IConfigurationReader configurationReader)
            : base(configPath, configurationReader)
        { }

        protected override void ApplyPostBuildConfiguration(TDefinition config, TMonitor instance)
        {
            // todo: determine how to configure handlers
            // should the handlers be responsible for defining the monitors they listen to?

            //foreach (var currentHandler in config.Handlers.SelectMany(x => _resultHandlerFactory.Build(x)))
            //    instance.Updated += r => currentHandler.Handle(r);

            if (!string.IsNullOrWhiteSpace(config.DisplayName))
                instance.Name = config.DisplayName;

            if (!string.IsNullOrWhiteSpace(config.Description))
                instance.Description = config.Description;
        }

        // Explicit IFactory<IMonitor> implementation
        IEnumerable<string> IFactory<IMonitor>.SupportedTypeValues => SupportedTypeValues;

        IEnumerable<IMonitor> IFactory<IMonitor>.Build(string name)
        {
            return Build(name).Cast<IMonitor>();
        }

        IEnumerable<IMonitor> IFactory<IMonitor>.Build()
        {
            return Build().Cast<IMonitor>();
        }
    }
}