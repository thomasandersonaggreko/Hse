namespace Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    /// <summary>
    /// The queryable x.
    /// </summary>
    public static class QueryableX
    {
        /// <summary>
        /// To the list asynchronous.
        /// </summary>
        /// <typeparam name="T">the type of projection</typeparam>
        /// <param name="queryable">The queryable.</param>
        /// <returns>The list</returns>
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> queryable)
        {
            return ((IAsyncCursorSource<T>)queryable).ToListAsync();
        }
    }
}