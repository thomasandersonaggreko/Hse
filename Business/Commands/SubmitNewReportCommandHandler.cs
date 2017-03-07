using MessageBus;

namespace Business.Commands
{
    using System.Threading.Tasks;

    using Business.Events;
    using Business.Sdk;

    using Contracts;

    /// <summary>
    /// The submit new report command.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    public class SubmitNewReportCommandHandler<TObject> : CommandHandler<SubmitNewReportCommand<TObject>>
        where TObject : DomainObject
    {
        /// <summary>
        /// The datastore
        /// </summary>
        private readonly IDatamapper datastore;

        /// <summary>
        /// The date time provider
        /// </summary>
        private readonly IDateTimeProvider dateTimeProvider;

        /// <summary>
        /// The notifier
        /// </summary>
        private readonly INotifier notifier;

        /// <summary>
        /// The reference number generator
        /// </summary>
        private readonly IReferenceNumberGenerator referenceNumberGenerator;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IBus eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitNewReportCommandHandler{TObject}"/> class. 
        /// </summary>
        /// <param name="datastore">
        /// The datastore.
        /// </param>
        /// <param name="notifier">
        /// The notifier.
        /// </param>
        /// <param name="dateTimeProvider">
        /// The date time provider.
        /// </param>
        /// <param name="referenceNumberGenerator">
        /// The reference number generator.
        /// </param>
        /// <param name="eventBus">The event bus</param>
        public SubmitNewReportCommandHandler(
            IDatamapper datastore,
            INotifier notifier,
            IDateTimeProvider dateTimeProvider,
            IReferenceNumberGenerator referenceNumberGenerator, 
            IBus eventBus)
        {
            this.datastore = datastore;
            this.notifier = notifier;
            this.dateTimeProvider = dateTimeProvider;
            this.referenceNumberGenerator = referenceNumberGenerator;
            this.eventBus = eventBus;
        }

        /// <summary>
        /// Invokes the domain logic asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// return the task
        /// </returns>
        protected override async Task InvokeDomainLogicAsync(SubmitNewReportCommand<TObject> request)
        {
            request.DomainObject.ReferenceNumber = this.referenceNumberGenerator.Generate();
            this.SetAuditFields(request);
            await this.datastore.SaveAsync(request.DomainObject).ConfigureAwait(false);
            var businessEvent = new NewReportSubmittedEvent<TObject>() { DomainObject = request.DomainObject };
            this.notifier.Notify(businessEvent);
            await this.eventBus.PublishAsync(businessEvent).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the audit fields.
        /// </summary>
        /// <param name="request">The request.</param>
        private void SetAuditFields(SubmitNewReportCommand<TObject> request)
        {
            request.DomainObject.Created = this.dateTimeProvider.Now;
            request.DomainObject.CreatedBy = request.ExecutingUser.Identity.Name;
        }
    }
}