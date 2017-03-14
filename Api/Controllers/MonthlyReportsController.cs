namespace Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Business.Queries;
    using Business.Sdk;

    using HSEModel.ReadModel;

    using Infrastructure;

    /// <summary>
    /// The reports controller.
    /// </summary>
    public class MonthlyReportsController : HseApiController
    {
        /// <summary>
        /// Gets the specified report type.
        /// </summary>
        /// <param name="reportType">Type of the report.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns>Action result</returns>
        public async Task<IHttpActionResult> Get(ReportType reportType, int year, int month)
        {
            MonthlyHighPotentialIncidentReportQuery query = new MonthlyHighPotentialIncidentReportQuery();
            query.ExecutingUser = this.User;
            query.Month = month;
            query.Year = year;
           
            QueryResult<MonthlyHighPotentialIncidents> queryResult = await InfrastructureContext.Bus.RequestAsync<MonthlyHighPotentialIncidentReportQuery, QueryResult<MonthlyHighPotentialIncidents>>(query).ConfigureAwait(false);

            switch (queryResult.QueryResultReason)
            {
                case QueryResultReason.Successful:
                    return this.Ok(queryResult.List.FirstOrDefault());
                case QueryResultReason.NotAuthorised:
                    return this.Unauthorized();
                case QueryResultReason.UnexpectedError:
                    return this.InternalServerError();
                default:
                    return this.InternalServerError();
            }
        }
    }
}