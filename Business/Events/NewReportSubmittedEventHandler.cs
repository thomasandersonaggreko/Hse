namespace Business.Events
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Business.Commands;

    using Contracts;

    using HSEModel;
    using HSEModel.ReadModel;

    using Infrastructure;
    using Infrastructure.MessageBus;

    /// <summary>
    /// The new report submitted event handler.
    /// </summary>
    public class NewReportSubmittedEventHandler : INotificationHandler<NewReportSubmittedEvent<HighPotentialIncident>>
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The task handle</returns>
        public async Task HandleAsync(NewReportSubmittedEvent<HighPotentialIncident> @event)
        {
            // load monthly report based on year/month/user
            string id =
                $"{InfrastructureContext.DateTimeProvider.Now.Year}-{InfrastructureContext.DateTimeProvider.Now.Month}-{@event.ExecutingUser.Identity.Name}";

            MonthlyHighPotentialIncidents monthlyHighPotentialIncidents =
                await BusinessContext.Datamapper.Load<MonthlyHighPotentialIncidents>(id).ConfigureAwait(false);

            if (monthlyHighPotentialIncidents == null)
            {
                monthlyHighPotentialIncidents = new MonthlyHighPotentialIncidents();
                monthlyHighPotentialIncidents.Metadata = new Metadata();
                monthlyHighPotentialIncidents.Metadata.User = @event.ExecutingUser.Identity.Name;
                monthlyHighPotentialIncidents.Metadata.Date = $"{InfrastructureContext.DateTimeProvider.Now.Year}-{InfrastructureContext.DateTimeProvider.Now.Month}";
                monthlyHighPotentialIncidents.Id = id;
                monthlyHighPotentialIncidents.Daily = new List<MonthlyHighPotentialIncidentsTextSummary>();

                await BusinessContext.Datamapper.SaveAsync(monthlyHighPotentialIncidents).ConfigureAwait(false);
            }

            MonthlyHighPotentialIncidentsTextSummary textSummary = new MonthlyHighPotentialIncidentsTextSummary();
            textSummary.LocationName = @event.DomainObject.Location;
            textSummary.ActualImpact = @event.DomainObject.ActualLoss.Text;
            textSummary.PotentialImpact = @event.DomainObject.PotentialLoss.Text;
            textSummary.IncidentDate = @event.DomainObject.ReportDate;
            textSummary.Description = @event.DomainObject.LocationDescription;

             monthlyHighPotentialIncidents.Daily.Add(textSummary);
            await BusinessContext.Datamapper.UpdateAsync(monthlyHighPotentialIncidents).ConfigureAwait(false);
        }
    }
}