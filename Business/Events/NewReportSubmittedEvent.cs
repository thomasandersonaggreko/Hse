namespace Business.Commands
{
    using Contracts;

    public class NewReportSubmittedEvent<TObject> : BusinessEvent<TObject> where TObject : DomainObject
    {
        public TObject DomainObject { get; set; }
    }
}