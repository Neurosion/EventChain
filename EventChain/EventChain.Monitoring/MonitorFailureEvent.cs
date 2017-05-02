using System;
using System.Collections.Generic;
using EventChain.Core;
using EventChain.Core.Extensions;

namespace EventChain.Monitoring
{
    public class MonitorFailureEvent : IEvent
    {
        public DateTime CreatedOn => DateTime.Now;

        public string Name { get; private set; }
        public Priority Priority => Priority.High;
        public State State => State.Error;

        public DateTime? ValidUntil { get; set; }

        public IDictionary<string, string> Details { get; private set; }
        public MonitorFailureEvent(IMonitor monitor)
        {
            Name = $"{monitor.Name} failure";
            Details = new Dictionary<string, string>();
        }

        public MonitorFailureEvent(IMonitor monitor, Exception ex)
            :this(monitor)
        {
            Details.Add("Exception", ex.ToDetailString());
        }
    }
}