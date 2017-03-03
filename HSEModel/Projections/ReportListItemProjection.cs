namespace HSEModel.Projections
{
    using System;

    /// <summary>
    /// The report list item projection.
    /// </summary>
    public class ReportListItemProjection
    {
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the incident.
        /// </summary>
        /// <value>
        /// The type of the incident.
        /// </value>
        public IncidentType IncidentType { get; set; }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the last updated by.
        /// </summary>
        /// <value>
        /// The last updated by.
        /// </value>
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>
        /// The reference number.
        /// </value>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the reported by.
        /// </summary>
        /// <value>
        /// The name of the reported by.
        /// </value>
        public string ReportedByName { get; set; }
    }
}