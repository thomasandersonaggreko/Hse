using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEModel.Projections
{
    public class ReportListItemProjection
    {
        public string ReportedByName { get; set; }
       
        public IndicidentType IncidentType { get; set; }

        public int Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
