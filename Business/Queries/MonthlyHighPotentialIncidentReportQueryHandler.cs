namespace Business.Queries
{
    using System.Linq;

    using Business.Sdk;

    using Data;

    using HSEModel.ReadModel;

    /// <summary>
    /// The monthly high potential incident report query handler.
    /// </summary>
    internal class MonthlyHighPotentialIncidentReportQueryHandler : QueryHandler<MonthlyHighPotentialIncidentReportQuery, MonthlyHighPotentialIncidents>
    {
        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="datamapper">The datastore.</param>
        /// <param name="queryParms">The query.</param>
        /// <returns>
        /// returns the queryable list of domain objects
        /// </returns>
        public override IQueryable<MonthlyHighPotentialIncidents> RunQuery(IDatamapper datamapper, MonthlyHighPotentialIncidentReportQuery queryParms)
        {
            string id = $"{queryParms.Year}-{queryParms.Month}-{queryParms.ExecutingUser.Identity.Name}";
            return from item in datamapper.Query<MonthlyHighPotentialIncidents>() where item.Id == id select item;
        }
    }
}