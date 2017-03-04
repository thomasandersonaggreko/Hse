namespace Contracts
{
    /// <summary>
    /// The EventBus interface.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Publishes the specified business event.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="businessEvent">The business event.</param>
        void Publish<T>(BusinessEvent<T> businessEvent) where T : DomainObject;

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="handler">The handler.</param>
        void Subscribe<T>(IEventHandler<T> handler);
    }

    /// <summary>
    /// The EventHandler interface.
    /// </summary>
    /// <typeparam name="T">The domain object
    /// </typeparam>
    public interface IEventHandler<T>
    {
        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        void Handle(T @event);
    }
}