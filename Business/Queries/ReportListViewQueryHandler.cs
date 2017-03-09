namespace Business.Queries
{
    using System.Linq;

    using Business.Sdk;

    using Contracts;

    using Data;

    using HSEModel.Projections;

    /// <summary>
    /// The report list view query.
    /// </summary>
    internal class ReportListViewQueryHandler : QueryHandler<ReportListViewQuery, ReportListItemProjection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListViewQueryHandler"/> class. 
        /// </summary>
        /// <param name="datamapper">
        /// The datamapper.
        /// </param>
        public ReportListViewQueryHandler(IDatamapper datamapper)
            : base(datamapper)
        {
        }

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <typeparam name="ReportListItemProjection">The type of the list item projection.</typeparam>
        /// <param name="datamapper">The datastore.</param>
        /// <returns>the query results</returns>
        public override IQueryable<ReportListItemProjection> RunQuery<ReportListItemProjection>(IDatamapper datamapper)
        {
            // datastore.Query<ReportListItemProjection>()
            // .Select<ReportListItemProjection, ReportListItemProjection>(x => x.)
            return from item in datamapper.Query<ReportListItemProjection>() select item;
        }
    }
}