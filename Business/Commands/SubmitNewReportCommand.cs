namespace Business.Commands
{
    using System.Security.Principal;

    using Contracts;

    public class SubmitNewReportCommand<TDomainObject> : GenericCommand<TDomainObject> where TDomainObject : DomainObject
    {
        private IDatamapper datastore;

        private IEventBus eventBus;

        private INotifier notifier;

        private IDateTimeProvider dateTimeProvider;

        private IReferenceNumberGenerator referenceNumberGenerator;

        public SubmitNewReportCommand(IDatamapper datastore, INotifier notifier, IDateTimeProvider dateTimeProvider, IReferenceNumberGenerator referenceNumberGenerator)
        {
            this.datastore = datastore;
            this.notifier = notifier;
            this.dateTimeProvider = dateTimeProvider;
            this.referenceNumberGenerator = referenceNumberGenerator;
        }

        protected override void InvokeDomainLogic(IPrincipal user)
        {
            this.DomainObject.ReferenceNumber = this.referenceNumberGenerator.Generate();
            this.SetAuditFields(user);
            this.datastore.Save(this.DomainObject);
            var businessEvent = new NewReportSubmittedEvent<TDomainObject>() { DomainObject = this.DomainObject };
            this.notifier.Notify(businessEvent);
            this.eventBus.Publish(businessEvent);
        }

        private void SetAuditFields(IPrincipal user)
        {
            this.DomainObject.Created = this.dateTimeProvider.Now;
            this.DomainObject.CreatedBy = user.Identity.Name;
        }
    }
}