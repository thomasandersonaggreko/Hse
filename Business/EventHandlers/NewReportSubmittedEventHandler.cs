namespace Business.EventHandlers
{
    using System;

    using Business.Commands;

    using Contracts;

    using HSEModel;

    /// <summary>
    /// The new report submitted event handler.
    /// </summary>
    public class NewReportSubmittedEventHandler : IEventHandler<SubmitNewReportCommand<HighPotentialIncident>>
    {
        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Handle(SubmitNewReportCommand<HighPotentialIncident> @event)
        {
            // TODO: this is were reports would be updated in real time, where appropriate
        }
    }
}