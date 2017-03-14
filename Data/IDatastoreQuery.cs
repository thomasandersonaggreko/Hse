namespace Data
{
    using System.Linq;

    /// <summary>
    /// The DatastoreQuery interface.
    /// </summary>
    /// <typeparam name="T">the return type
    /// </typeparam>
    /// <typeparam name="TK">the query
    /// </typeparam>
    public interface IDatastoreQuery<out T, in TK> where T : class
    {
        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="datamapper">The datastore.</param>
        /// <param name="queryParams">The query parameters.</param>
        /// <returns>
        /// query result
        /// </returns>
        IQueryable<T> RunQuery(IDatamapper datamapper, TK queryParams);
    }
}