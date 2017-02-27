namespace HSEModel
{
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;

    using Contracts;

    public class HighPotentialIncident : Report
    {
        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;
        public bool AggrekoEquipment { get; set; }

    }

  

    

    
  
}