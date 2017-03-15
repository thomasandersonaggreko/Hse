namespace Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Business.Queries;
    using Business.Sdk;

    using HSEModel.ReadModel;

    using Infrastructure;
    using Infrastructure.MessageBus;

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
        public Task<IHttpActionResult> Get(ReportType reportType, int year, int month)
        {
            MonthlyHighPotentialIncidentReportQuery query = new MonthlyHighPotentialIncidentReportQuery();
            query.Month = month;
            query.Year = year;

            return this.ExecuteQuerySingle<MonthlyHighPotentialIncidentReportQuery, MonthlyHighPotentialIncidents>(query);
        }
    }
}