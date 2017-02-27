namespace Business.Queries
{
    using System.Collections.Generic;
    using System.Linq;

    public class QueryResult<T>
    {
        #region Properties

        public QueryResultReason QueryResultReason { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is populated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is populated; otherwise, <c>false</c>.
        /// </value>
        public bool IsPopulated { get; private set; }

        /// <summary>
        /// Returns true if paging controls are rendered around this list
        /// </summary>
        public bool HasPagingControls { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is truncated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is truncated; otherwise, <c>false</c>.
        /// </value>
        public bool IsTruncated { get; private set; }

        /// <summary>
        /// Indicates the total number of records in a paged list
        /// </summary>
        public int TotalNumberOfRecords { get; private set; }

        /// <summary>
        /// Indicates the total number of pages in a paged list
        /// </summary>
        public int TotalNumberOfPages { get; private set; }

        public IList<T> List { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        public QueryResult()
        {
            this.IsPopulated = false;
            this.IsTruncated = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        /// <exception cref="T:System.ArgumentNullException">list is null.</exception>
        public QueryResult(IEnumerable<T> list)
        {
            this.List = list.ToList();
            this.IsPopulated = true;
            this.IsTruncated = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="truncated">if set to <c>true</c> [truncated].</param>
        public QueryResult(IEnumerable<T> list, bool truncated)
        {
            this.List = list.ToList();
            this.IsPopulated = true;
            this.IsTruncated = truncated;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="truncated">if set to <c>true</c> [truncated].</param>
        /// <param name="totalNumberOfRecords">the total number of records</param>
        /// <param name="totalNumberOfPages">the total number of pages</param>
        public QueryResult(IEnumerable<T> list, bool truncated, int totalNumberOfRecords, int totalNumberOfPages)

        {
            this.List = list.ToList();
            this.IsPopulated = true;
            this.IsTruncated = truncated;
            this.TotalNumberOfRecords = totalNumberOfRecords;
            this.TotalNumberOfPages = totalNumberOfPages;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="valueObject">The value object.</param>
        public QueryResult(T valueObject)
        {
            this.List = new List<T>() { valueObject };
            this.IsPopulated = true;
            this.IsTruncated = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult{T}"/> class.
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="truncated">if set to <c>true</c> [truncated].</param>
        /// <param name="populated">if set to <c>true</c> [populated].</param>
        public QueryResult(IEnumerable<T> list, bool truncated, bool populated)

        {
            this.List = list.ToList();
            this.IsPopulated = populated;
            this.IsTruncated = truncated;
        }

        #endregion

        public QueryResult<T> MarkHasPagingControls()
        {
            this.HasPagingControls = true;
            return this;
        }

    }
}