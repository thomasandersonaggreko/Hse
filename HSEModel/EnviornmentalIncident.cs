namespace HSEModel
{
    public class EnviornmentalIncident : Report
    {

        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;
        public bool HazardId { get; set; }
       
        public bool SecondaryDescId { get; set; }
        public bool OtherSecondaryType { get; set; }
       
        public bool AggrekoEquipment { get; set; }
      
        public bool SpiltGround { get; set; }
        public bool ContainedBund { get; set; }
        public bool Emitted { get; set; }
      

    }
}