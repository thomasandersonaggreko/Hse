namespace Business.Queries
{
    using Business.Sdk;

    using HSEModel.ReadModel;

    /// <summary>
    /// The monthly high potential incident report query.
    /// </summary>
    public class MonthlyHighPotentialIncidentReportQuery : Query<MonthlyHighPotentialIncidents>
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public int Month { get; set; }
    }
}