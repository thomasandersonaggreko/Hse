namespace HSEModel
{
    /// <summary>
    /// The risk of road traffic incident.
    /// </summary>
    public class RiskOfRoadTrafficIncident : Risk
    {
        /// <summary>
        /// Gets or sets a value indicating whether [other vehicle type].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [other vehicle type]; otherwise, <c>false</c>.
        /// </value>
        public bool OtherVehicleType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [vehicle type identifier].
        /// </summary>
        /// <value>
        /// <c>true</c> if [vehicle type identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool VehicleTypeId { get; set; }
    }
}