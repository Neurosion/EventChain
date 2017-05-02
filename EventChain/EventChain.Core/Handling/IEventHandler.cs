namespace EventChain.Core.Handling
{
    public interface IEventHandler
    {
        void Handle(IEvent @event);
    }
}