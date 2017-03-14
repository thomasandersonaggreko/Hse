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
            string id =
                $"{InfrastructureContext.DateTimeProvider.Now.Year}-{InfrastructureContext.DateTimeProvider.Now.Month}-{@event.ExecutingUser.Identity.Name}";

            MonthlyHighPotentialIncidents monthlyHighPotentialIncidents = await this.GetMonthlyHighPotentialIncidents(id, @event.ExecutingUser.Identity.Name).ConfigureAwait(false);

            this.Update(monthlyHighPotentialIncidents, @event);

            await this.SaveChanges(monthlyHighPotentialIncidents).ConfigureAwait(false);
        }

        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <typeparam name="T">the domain object type</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>loads the domain object</returns>
        private Task<T> Load<T>(string id) where T : DomainObject
        {
            return BusinessContext.Datamapper.Load<T>(id);
        }

        /// <summary>
        /// Creates the new monthly high potential incidents.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>returns MonthlyHighPotentialIncidents object</returns>
        private MonthlyHighPotentialIncidents CreateNewMonthlyHighPotentialIncidents(string id, string user)
        {
            MonthlyHighPotentialIncidents monthlyHighPotentialIncidents = new MonthlyHighPotentialIncidents();
            monthlyHighPotentialIncidents.Metadata = new Metadata();
            monthlyHighPotentialIncidents.Metadata.User = user;
            monthlyHighPotentialIncidents.Metadata.Date = $"{InfrastructureContext.DateTimeProvider.Now.Year}-{InfrastructureContext.DateTimeProvider.Now.Month}";
            monthlyHighPotentialIncidents.Id = id;
            monthlyHighPotentialIncidents.Daily = new List<MonthlyHighPotentialIncidentsTextSummary>();
            return monthlyHighPotentialIncidents;
        }

        /// <summary>
        /// Gets the monthly high potential incidents.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>returns the MonthlyHighPotentialIncidents</returns>
        private async Task<MonthlyHighPotentialIncidents> GetMonthlyHighPotentialIncidents(string id, string user)
        {
            MonthlyHighPotentialIncidents monthlyHighPotentialIncidents =
               await this.Load<MonthlyHighPotentialIncidents>(id).ConfigureAwait(false);

            if (monthlyHighPotentialIncidents == null)
            {
                monthlyHighPotentialIncidents = this.CreateNewMonthlyHighPotentialIncidents(id, user);
            }

            return monthlyHighPotentialIncidents;
        }

        /// <summary>
        /// Updates the specified monthly high potential incidents.
        /// </summary>
        /// <param name="monthlyHighPotentialIncidents">The monthly high potential incidents.</param>
        /// <param name="event">The event.</param>
        private void Update(MonthlyHighPotentialIncidents monthlyHighPotentialIncidents, NewReportSubmittedEvent<HighPotentialIncident> @event)
        {
            MonthlyHighPotentialIncidentsTextSummary textSummary = new MonthlyHighPotentialIncidentsTextSummary();
            textSummary.LocationName = @event.DomainObject.Location;
            textSummary.ActualImpact = @event.DomainObject.ActualLoss.Text;
            textSummary.PotentialImpact = @event.DomainObject.PotentialLoss.Text;
            textSummary.IncidentDate = @event.DomainObject.ReportDate;
            textSummary.Description = @event.DomainObject.LocationDescription;

            monthlyHighPotentialIncidents.Daily.Add(textSummary);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <typeparam name="T">the type of domain object</typeparam>
        /// <param name="object">The object.</param>
        /// <returns>return the task handle</returns>
        private Task SaveChanges<T>(T @object) where T : DomainObject
        {
            return BusinessContext.Datamapper.UpdateAsync(@object);
        }
    }
}