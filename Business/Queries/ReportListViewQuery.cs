namespace Business.Queries
{
    using System.Linq;

    using Contracts;

    using HSEModel.Projections;

    /// <summary>
    /// The report list view query.
    /// </summary>
    public class ReportListViewQuery : GenericQuery<ReportListItemProjection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListViewQuery"/> class.
        /// </summary>
        /// <param name="datamapper">The datamapper.</param>
        public ReportListViewQuery(IDatamapper datamapper)
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