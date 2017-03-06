namespace Contracts
{
    /// <summary>
    /// The Notifier interface.
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Notifies the specified business event.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="businessEvent">The business event.</param>
        void Notify<T>(IBusinessEvent<T> businessEvent) where T : DomainObject;
    }

    /// <summary>
    /// The notifier.
    /// </summary>
    public class Notifier : INotifier
    {
        /// <summary>
        /// Notifies the specified business event.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="businessEvent">The business event.</param>
        public void Notify<T>(IBusinessEvent<T> businessEvent) where T : DomainObject
        {
        }
    }
}