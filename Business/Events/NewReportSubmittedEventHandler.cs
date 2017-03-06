using System.Threading.Tasks;
using MessageBus;

namespace Business.Events
{
    using Business.Commands;

    using Contracts;

    using HSEModel;

    /// <summary>
    /// The new report submitted event handler.
    /// </summary>
    public class NewReportSubmittedEventHandler : INotificationHandler<SubmitNewReportCommand<HighPotentialIncident>>
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The task handle</returns>
        public Task HandleAsync(SubmitNewReportCommand<HighPotentialIncident> @event)
        {
            // TODO: this is were reports would be updated in real time, where appropriate
            return Task.CompletedTask;
        }
    }
}