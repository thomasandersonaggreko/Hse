namespace Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Business.Commands;

    using HSEModel;

    /// <summary>
    /// The high potential incident controller.
    /// </summary>
    public class HighPotentialIncidentController : HseApiController
    {
        /// <summary>
        /// Posts the specified report. API/HighPotentialIncident
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns>The HTTP action result</returns>
        public Task<IHttpActionResult> Post([FromBody]HighPotentialIncident report)
        {
            SubmitNewReportCommand<HighPotentialIncident> command = new SubmitNewReportCommand<HighPotentialIncident>
                                                                        {
                                                                            ExecutingUser = this.User,
                                                                            DomainObject = report
                                                                        };

            return this.Execute(command);
        }
    }
}