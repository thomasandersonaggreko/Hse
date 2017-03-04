namespace Business.Queries
{
    /// <summary>
    /// The QueryFactory interface.
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <typeparam name="T">The query result object</typeparam>
        /// <returns>The query</returns>
        T GetQuery<T>();
    }
}