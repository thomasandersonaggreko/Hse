namespace Contracts
{
    /// <summary>
    /// The business event.
    /// </summary>
    /// <typeparam name="TObject">The Domain Object
    /// </typeparam>
    public class BusinessEvent<TObject>
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