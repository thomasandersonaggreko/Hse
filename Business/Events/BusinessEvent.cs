using Contracts;
using MessageBus;

namespace Business.Commands
{
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
    }
}