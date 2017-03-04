namespace Contracts
{
    using System.Linq;

    /// <summary>
    /// The Datastore interface.
    /// </summary>
    public interface IDatastore
    {
        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <returns>Query result</returns>
        IQueryable<T> Query<T>() where T : class;

        /// <summary>
        /// Saves the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="domainObject">The domain object.</param>
        void Save<T>(T domainObject) where T : DomainObject;
    }
}