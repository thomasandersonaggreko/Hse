namespace Business.Commands
{
    using System.ComponentModel.DataAnnotations;

    using Business.Sdk;

    /// <summary>
    /// The close high potential incident.
    /// </summary>
    public class CloseHighPotentialIncidentCommand : Command
    {
        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        /// <value>
        /// The remark.
        /// </value>
        [Required]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public string ReportId { get; set; }
    }
}