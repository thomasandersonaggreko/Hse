namespace Business.Events
{
    using System.Security.Principal;

    using Contracts;

    using Infrastructure.MessageBus;

    /// <summary>
    /// The business event.
    /// </summary>
    /// <typeparam name="TObject">The Domain Object
    /// </typeparam>
    public class BusinessEvent<TObject> : IBusinessEvent<TObject>, INotification
        where TObject : DomainObject
    {
        /// <summary>
        /// Gets or sets the domain object.
        /// </summary>
        /// <value>
        /// The domain object.
        /// </value>
        public TObject DomainObject { get; set; }

        /// <summary>
        /// Gets or sets the executing user.
        /// </summary>
        /// <value>
        /// The executing user.
        /// </value>
        public IPrincipal ExecutingUser { get; set; }
    }
}