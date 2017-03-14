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
        /// Runs the query.
        /// </summary>
        /// <param name="datamapper">The datastore.</param>
        /// <param name="queryParms">The query.</param>
        /// <returns>
        /// returns the queryable list of domain objects
        /// </returns>
        public override IQueryable<ReportListItemProjection> RunQuery(IDatamapper datamapper, ReportListViewQuery queryParms)
        {
            return from item in datamapper.Query<ReportListItemProjection>() select item;
        }
    }
}