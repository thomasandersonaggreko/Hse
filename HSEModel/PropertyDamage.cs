namespace HSEModel
{
    /// <summary>
    /// The property damage.
    /// </summary>
    public class PropertyDamage : Report
    {
        /// <summary>
        /// Gets or sets a value indicating whether [aggreko equipment].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [aggreko equipment]; otherwise, <c>false</c>.
        /// </value>
        public bool AggrekoEquipment { get; set; }

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
        /// Gets or sets a value indicating whether [other hazard].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other hazard]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherHazard { get; set; }
    }
}