namespace Business.Eventbus
{
    using Contracts;

    /// <summary>
    /// The EventHandlerFactory interface.
    /// </summary>
    public interface IEventHandlerFactory
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">The command type</typeparam>
        /// <returns>The event handler</returns>
        IEventHandler<T> Resolve<T>();
    }
}