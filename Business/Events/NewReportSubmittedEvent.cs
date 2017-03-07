namespace Business.Events
{
    using Business.Commands;

    using Contracts;

    /// <summary>
    /// The new report submitted event.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    public class NewReportSubmittedEvent<TObject> : BusinessEvent<TObject>
        where TObject : DomainObject
    {
    }
}