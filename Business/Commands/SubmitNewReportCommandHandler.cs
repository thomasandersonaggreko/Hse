namespace Business.Commands
{
    using System.Threading.Tasks;

    using Business.Events;
    using Business.Sdk;

    using Contracts;

    using Infrastructure;
    using Infrastructure.DateTime;

    /// <summary>
    /// The submit new report command.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    internal class SubmitNewReportCommandHandler<TObject> : CommandHandler<SubmitNewReportCommand<TObject>>
        where TObject : DomainObject
    {
        /// <summary>
        /// Invokes the domain logic asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// return the task
        /// </returns>
        protected override async Task InvokeDomainLogicAsync(SubmitNewReportCommand<TObject> request)
        {
            request.DomainObject.ReferenceNumber = BusinessContext.ReferenceNumberGenerator.Generate();
            this.SetAuditFields(request);
            await BusinessContext.Datamapper.SaveAsync(request.DomainObject).ConfigureAwait(false);
            var businessEvent = new NewReportSubmittedEvent<TObject>() { DomainObject = request.DomainObject };
            BusinessContext.Notifier.Notify(businessEvent);
            await InfrastructureContext.Bus.PublishAsync(businessEvent).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the audit fields.
        /// </summary>
        /// <param name="request">The request.</param>
        private void SetAuditFields(SubmitNewReportCommand<TObject> request)
        {
            request.DomainObject.Created = InfrastructureContext.DateTimeProvider.Now;
            request.DomainObject.CreatedBy = request.ExecutingUser.Identity.Name;
        }
    }
}