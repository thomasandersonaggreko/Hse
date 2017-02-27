namespace HSEModel
{
    public class OccupationalIllnessReport : Report
    {

        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;
        public bool AdaptedWorkDays { get; set; }

        public bool AdaptedWorkRequired { get; set; }

       

        public bool HazardId { get; set; }

       

        public bool LostDays { get; set; }

        public bool OtherHazard { get; set; }

       
    }
}