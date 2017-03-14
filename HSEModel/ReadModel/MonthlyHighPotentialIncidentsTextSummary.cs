using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEModel.ReadModel
{
    /// <summary>
    /// The monthly high potential incidents text summary.
    /// </summary>
    public class MonthlyHighPotentialIncidentsTextSummary
    {
        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>
        /// The name of the location.
        /// </value>
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        public string AreaName { get; set; }

        /// <summary>
        /// Gets or sets the incident date.
        /// </summary>
        /// <value>
        /// The incident date.
        /// </value>
        public DateTime IncidentDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the actual impact.
        /// </summary>
        /// <value>
        /// The actual impact.
        /// </value>
        public string ActualImpact { get; set; }

        /// <summary>
        /// Gets or sets the potential impact.
        /// </summary>
        /// <value>
        /// The potential impact.
        /// </value>
        public string PotentialImpact { get; set; }
    }
}
