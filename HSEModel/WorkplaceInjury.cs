namespace HSEModel
{
    /// <summary>
    /// The workplace injury.
    /// </summary>
    public class WorkplaceInjury : Report
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
        /// Gets or sets a value indicating whether [lost days].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [lost days]; otherwise, <c>false</c>.
        /// </value>
        public bool LostDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [medical attention].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [medical attention]; otherwise, <c>false</c>.
        /// </value>
        public bool MedicalAttention { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [other hazard].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other hazard]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherHazard { get; set; }

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
    }
}