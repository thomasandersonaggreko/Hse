namespace Contracts
{
    using System.Linq;

    /// <summary>
    /// The DatastoreQuery interface.
    /// </summary>
    public interface IDatastoreQuery
    {
        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="datastore">The datastore.</param>
        /// <returns>query result</returns>
        IQueryable<T> RunQuery<T>(IDatastore datastore) where T : class;
    }
}