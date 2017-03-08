namespace Business
{
    using Contracts;

    /// <summary>
    /// The IBusinessEvent interface
    /// </summary>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    public interface IBusinessEvent<TObject>
        where TObject : DomainObject
    {
        /// <summary>
        /// Gets or sets the domain object.
        /// </summary>
        /// <value>
        /// The domain object.
        /// </value>
        TObject DomainObject { get; set; }
    }
}