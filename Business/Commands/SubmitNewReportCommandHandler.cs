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
            this.GenerateReferenceNumber(request.DomainObject);
            this.SetAuditFields(request.DomainObject, request.ExecutingUser.Identity.Name);
            await this.SaveAsync(request.DomainObject).ConfigureAwait(false);

            NewReportSubmittedEvent<TObject> businessEvent = new NewReportSubmittedEvent<TObject>() { DomainObject = request.DomainObject, ExecutingUser = request.ExecutingUser };
            BusinessContext.Notifier.Notify(businessEvent);
            await InfrastructureContext.Bus.PublishAsync(businessEvent).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the audit fields.
        /// </summary>
        /// <param name="domainObject">The request.</param>
        /// <param name="user">The user.</param>
        private void SetAuditFields(TObject domainObject, string user)
        {
            domainObject.Created = InfrastructureContext.DateTimeProvider.Now;
            domainObject.CreatedBy = user;
        }

        /// <summary>
        /// Generates the reference number.
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        private void GenerateReferenceNumber(TObject domainObject)
        {
            domainObject.ReferenceNumber = BusinessContext.ReferenceNumberGenerator.Generate();
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>returns the async handle</returns>
        private Task SaveAsync(TObject domainObject)
        {
            return BusinessContext.Datamapper.SaveAsync(domainObject);
        }
    }
}