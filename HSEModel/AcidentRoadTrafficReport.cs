namespace HSEModel
{
    /// <summary>
    /// The accident road traffic report.
    /// </summary>
    public class AccidentRoadTrafficReport : Report
    {
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
        /// Gets or sets a value indicating whether [other vehicle type].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other vehicle type]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherVehicleType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [persons injured].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [persons injured]; otherwise, <c>false</c>.
        /// </value>
        public bool PersonsInjured { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [secondary desc identifier].
        /// </summary>
        /// <value>
        /// <c>true</c> if [secondary desc identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool SecondaryDescId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [vehicle type identifier].
        /// </summary>
        /// <value>
        /// <c>true</c> if [vehicle type identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool VehicleTypeId { get; set; }
    }
}