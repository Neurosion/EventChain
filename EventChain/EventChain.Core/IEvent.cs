using System;
using System.Collections.Generic;

namespace EventChain.Core
{
    public interface IEvent
    {
        string Name { get; }
        DateTime CreatedOn { get; }
        DateTime? ValidUntil { get; }
        Priority Priority { get; }
        State State { get; }
        IDictionary<string, string> Details { get; }
    }
}