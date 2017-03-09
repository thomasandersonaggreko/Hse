namespace Business.Events
{
    using System.Threading.Tasks;

    using Infrastructure.MessageBus;

    /// <summary>
    /// The close high potential incident event handler.
    /// </summary>
    public class CloseHighPotentialIncidentEventHandler : INotificationHandler<CloseHighPotentialIncidentEvent>
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The task handle</returns>
        public Task HandleAsync(CloseHighPotentialIncidentEvent @event)
        {
            // TODO: this is were reports would be updated in real time, where appropriate
            return Task.CompletedTask;
        }
    }
}