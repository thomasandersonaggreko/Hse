namespace Contracts
{
    public interface IEventBus
    {
        void Publish<T>(BusinessEvent<T> businessEvent) where T : DomainObject;

        void Subscribe<T>(IEventHandler<T> handler);
    }

    public interface IEventHandler<T>
    {
        void Handle(T @event);
    }
}