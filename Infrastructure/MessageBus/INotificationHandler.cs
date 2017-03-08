namespace Infrastructure.MessageBus
{
    using System.Threading.Tasks;

    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification message</param>
        Task HandleAsync(TNotification notification);
    }
}