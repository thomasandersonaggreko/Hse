namespace Business.Queries
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The query result.
    /// </summary>
    /// <typeparam name="T">The type of object within the result
    /// </typeparam>
    public class QueryResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="queryResultReason">The query result reason.</param>
        public QueryResult(QueryResultReason queryResultReason)
        {
            this.QueryResultReason = queryResultReason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        /// <exception cref="T:System.ArgumentNullException">list is null.</exception>
        public QueryResult(IEnumerable<T> list)
        {
            this.List = list.ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="totalNumberOfRecords">the total number of records</param>
        public QueryResult(IEnumerable<T> list, int totalNumberOfRecords)
        {
            this.List = list.ToList();
            this.TotalNumberOfRecords = totalNumberOfRecords;
        }

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public IList<T> List { get; set; }

        /// <summary>
        /// Gets the query result reason.
        /// </summary>
        /// <value>
        /// The query result reason.
        /// </value>
        public QueryResultReason QueryResultReason { get; private set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        /// <value>
        /// The total number of pages.
        /// </value>
        public int TotalNumberOfPages { get; private set; }

        /// <summary>
        /// Gets the total number of records.
        /// </summary>
        /// <value>
        /// The total number of records.
        /// </value>
        public int TotalNumberOfRecords { get; private set; }
    }
}