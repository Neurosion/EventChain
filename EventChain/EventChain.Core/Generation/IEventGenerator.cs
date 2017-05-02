using System;

namespace EventChain.Core.Generation
{
    public interface IEventGenerator
    {
        event Action<IEvent> NewEvent;
    }
}