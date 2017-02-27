using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSEModel
{
    public enum IndicidentType
    {
        RoadTrafficAccident,

        HighPotentialIncident
    }
    public class AcidentRoadTrafficReport : Report
    {
        //required
        public override IndicidentType IncidentType => IndicidentType.RoadTrafficAccident;

        public bool VehicleTypeId { get; set; }
        public bool OtherVehicleType { get; set; }
        public bool HazardId { get; set; }
        public bool OtherHazard { get; set; }
       
        public bool SecondaryDescId { get; set; }
        public bool OtherSecondaryType { get; set; }
      
        public bool MedicalAttention { get; set; }
      
        public bool PersonsInjured { get; set; }

        
    }
}