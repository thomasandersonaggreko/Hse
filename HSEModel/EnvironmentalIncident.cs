namespace HSEModel
{
    /// <summary>
    /// The environmental incident.
    /// </summary>
    public class EnvironmentalIncident : Report
    {
        /// <summary>
        /// Gets or sets a value indicating whether [aggreko equipment].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [aggreko equipment]; otherwise, <c>false</c>.
        /// </value>
        public bool AggrekoEquipment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [contained bund].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contained bund]; otherwise, <c>false</c>.
        /// </value>
        public bool ContainedBund { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnviornmentalIncident"/> is emitted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if emitted; otherwise, <c>false</c>.
        /// </value>
        public bool Emitted { get; set; }

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
        /// Gets or sets a value indicating whether [other secondary type].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other secondary type]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherSecondaryType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [secondary desc identifier].
        /// </summary>
        /// <value>
        /// <c>true</c> if [secondary desc identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool SecondaryDescId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [spilt ground].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [spilt ground]; otherwise, <c>false</c>.
        /// </value>
        public bool SpiltGround { get; set; }
    }
}