namespace Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

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
        /// Saves the asynchronous.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>Returns the task</returns>
        Task SaveAsync<T>(T domainObject) where T : DomainObject;
    }
}