namespace Business.Commands
{
    using System.Threading.Tasks;

    using Business.Events;
    using Business.Sdk;

    using HSEModel;

    using Infrastructure;

    /// <summary>
    /// The close high potential incident handler.
    /// </summary>
    internal class CloseHighPotentialIncidentHandler : CommandHandler<CloseHighPotentialIncidentCommand>
    {
        /// <summary>
        /// Invokes the domain logic asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// return the task
        /// </returns>
        protected override async Task InvokeDomainLogicAsync(CloseHighPotentialIncidentCommand request)
        {
            HighPotentialIncident domainObject = await BusinessContext.Datamapper.Load<HighPotentialIncident>(request.ReportId).ConfigureAwait(false);
            domainObject.LastUpdated = InfrastructureContext.DateTimeProvider.Now;
            domainObject.LastUpdatedBy = request.ExecutingUser.Identity.Name;
            await BusinessContext.Datamapper.UpdateAsync(domainObject).ConfigureAwait(false);
            CloseHighPotentialIncidentEvent businessEvent = new CloseHighPotentialIncidentEvent() { DomainObject = domainObject };
            BusinessContext.Notifier.Notify(businessEvent);
            await InfrastructureContext.Bus.PublishAsync(businessEvent).ConfigureAwait(false);
        }
    }
}