namespace Data
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
        /// <param name="datamapper">The datastore.</param>
        /// <returns>query result</returns>
        IQueryable<T> RunQuery<T>(IDatamapper datamapper) where T : class;
    }
}