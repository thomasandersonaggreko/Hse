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
    public class ReportListViewQueryHandler : QueryHandler<ReportListViewQuery, ReportListItemProjection>
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
        /// <param name="datastore">The datastore.</param>
        /// <returns>the query results</returns>
        public override IQueryable<ReportListItemProjection> RunQuery<ReportListItemProjection>(IDatastore datastore)
        {
            // datastore.Query<ReportListItemProjection>()
            // .Select<ReportListItemProjection, ReportListItemProjection>(x => x.)
            return from item in datastore.Query<ReportListItemProjection>() select item;
        }
    }
}