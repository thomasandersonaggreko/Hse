namespace HSEModel
{
    public class WorkplaceInjury : Report
    {
        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;
        public bool HazardId { get; set; }
        public bool OtherHazard { get; set; }
      
        public bool SecondaryDescId { get; set; }
        public bool OtherSecondaryType { get; set; }
       
        public bool MedicalAttention { get; set; }
      
        public bool AggrekoEquipment { get; set; }
       
        public bool LostDays { get; set; }
        public bool AdaptedWorkRequired { get; set; }
        public bool AdaptedWorkDays { get; set; }
        

    }
}