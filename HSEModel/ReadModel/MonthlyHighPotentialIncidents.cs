namespace HSEModel.ReadModel
{
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    /// The monthly high potential incidents.
    /// </summary>
    public class MonthlyHighPotentialIncidents : DomainObject
    {
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>
        /// The metadata.
        /// </value>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets the daily.
        /// </summary>
        /// <value>
        /// The daily.
        /// </value>
        public IList<MonthlyHighPotentialIncidentsTextSummary> Daily { get; set; }
    }
}