namespace Contracts
{
    using System.Linq;

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
        /// Saves the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="domainObject">The domain object.</param>
        void Save<T>(T domainObject) where T : DomainObject;
    }
}