namespace HSEModel
{
    /// <summary>
    /// The occupational illness report.
    /// </summary>
    public class OccupationalIllnessReport : Report
    {
        /// <summary>
        /// Gets or sets a value indicating whether [adapted work days].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [adapted work days]; otherwise, <c>false</c>.
        /// </value>
        public bool AdaptedWorkDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [adapted work required].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [adapted work required]; otherwise, <c>false</c>.
        /// </value>
        public bool AdaptedWorkRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [hazard identifier].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hazard identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool HazardId { get; set; }

        /// <summary>
        /// Gets the type of the incident.
        /// </summary>
        /// <value>
        /// The type of the incident.
        /// </value>
        public override IncidentType IncidentType => IncidentType.RoadTrafficAccident;

        /// <summary>
        /// Gets or sets a value indicating whether [lost days].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [lost days]; otherwise, <c>false</c>.
        /// </value>
        public bool LostDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [other hazard].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other hazard]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherHazard { get; set; }
    }
}