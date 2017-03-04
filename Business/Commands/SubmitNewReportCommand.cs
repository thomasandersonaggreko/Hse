namespace Business.Commands
{
    using System.Security.Principal;

    using Contracts;

    /// <summary>
    /// The submit new report command.
    /// </summary>
    /// <typeparam name="TDomainObject">The domain object
    /// </typeparam>
    public class SubmitNewReportCommand<TDomainObject> : GenericCommand<TDomainObject>
        where TDomainObject : DomainObject
    {
        /// <summary>
        /// The datastore
        /// </summary>
        private IDatamapper datastore;

        /// <summary>
        /// The date time provider
        /// </summary>
        private IDateTimeProvider dateTimeProvider;

        /// <summary>
        /// The event bus
        /// </summary>
        private IEventBus eventBus;

        /// <summary>
        /// The notifier
        /// </summary>
        private INotifier notifier;

        /// <summary>
        /// The reference number generator
        /// </summary>
        private IReferenceNumberGenerator referenceNumberGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitNewReportCommand{TDomainObject}"/> class.
        /// </summary>
        /// <param name="datastore">The datastore.</param>
        /// <param name="notifier">The notifier.</param>
        /// <param name="dateTimeProvider">The date time provider.</param>
        /// <param name="referenceNumberGenerator">The reference number generator.</param>
        public SubmitNewReportCommand(
            IDatamapper datastore,
            INotifier notifier,
            IDateTimeProvider dateTimeProvider,
            IReferenceNumberGenerator referenceNumberGenerator)
        {
            this.datastore = datastore;
            this.notifier = notifier;
            this.dateTimeProvider = dateTimeProvider;
            this.referenceNumberGenerator = referenceNumberGenerator;
        }

        /// <summary>
        /// Invokes the domain logic.
        /// </summary>
        /// <param name="user">The user.</param>
        protected override void InvokeDomainLogic(IPrincipal user)
        {
            this.DomainObject.ReferenceNumber = this.referenceNumberGenerator.Generate();
            this.SetAuditFields(user);
            this.datastore.Save(this.DomainObject);
            var businessEvent = new NewReportSubmittedEvent<TDomainObject>() { DomainObject = this.DomainObject };
            this.notifier.Notify(businessEvent);
            this.eventBus.Publish(businessEvent);
        }

        /// <summary>
        /// Sets the audit fields.
        /// </summary>
        /// <param name="user">The user.</param>
        private void SetAuditFields(IPrincipal user)
        {
            this.DomainObject.Created = this.dateTimeProvider.Now;
            this.DomainObject.CreatedBy = user.Identity.Name;
        }
    }
}