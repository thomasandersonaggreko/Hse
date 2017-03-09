namespace Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;

    using MongoDB.Driver.Linq;

    /// <summary>
    /// The Datamapper interface.
    /// </summary>
    public interface IDatamapper
    {
        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Queryable list of domain objects</returns>
        IQueryable<T> Query<T>(IDatastoreQuery query) where T : class;

        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <returns>Queryable list of domain objects</returns>
        IQueryable<T> Query<T>() where T : class;

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>Return the async task</returns>
        Task SaveAsync<T>(T domainObject) where T : DomainObject;

        /// <summary>
        /// Updates the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>Return the async task</returns>
        Task UpdateAsync<T>(T domainObject) where T : DomainObject;

        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <typeparam name="T">the domain object</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>returns the domain object</returns>
        Task<T> Load<T>(string id) where T : DomainObject;
    }
}