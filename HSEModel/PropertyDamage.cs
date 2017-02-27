namespace HSEModel
{
    public class PropertyDamage : Report
    {
        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;

        public bool HazardId { get; set; }
        public bool OtherHazard { get; set; }
      
        public bool AggrekoEquipment { get; set; }
       

    }
}