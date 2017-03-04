namespace Business.Commands
{
    using Contracts;

    /// <summary>
    /// The new report submitted event.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    public class NewReportSubmittedEvent<TObject> : BusinessEvent<TObject>
        where TObject : DomainObject
    {
        /// <summary>
        /// Gets or sets the domain object.
        /// </summary>
        /// <value>
        /// The domain object.
        /// </value>
        public TObject DomainObject { get; set; }
    }
}