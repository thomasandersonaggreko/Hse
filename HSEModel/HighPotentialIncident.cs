namespace HSEModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The high potential incident.
    /// </summary>
    public class HighPotentialIncident : Report
    {
        /// <summary>
        /// Gets or sets a value indicating whether [aggreko equipment].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [aggreko equipment]; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool AggrekoEquipment { get; set; }

        /// <summary>
        /// Gets the type of the incident.
        /// </summary>
        /// <value>
        /// The type of the incident.
        /// </value>
        public override IncidentType IncidentType => IncidentType.HighPotentialIncident;
    }
}