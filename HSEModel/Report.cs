using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSEModel
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    using Contracts;

    public enum ReferenceDataEnum
    {
        PrimaryIncidentDescription,
            ActualImpact

    }

    public class ReferenceData
    {
        public int Id { get; set; }
        public ReferenceDataEnum Type { get; set; }
        public IList<ReferenceDataItem> Items { get; set; }
    }

    public class ReferenceDataItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    
    public abstract class Report : DomainObject
    {
        public string ReportedByName { get; set; }

        [Required]
        public abstract IndicidentType IncidentType { get; }

        [Required]  
        public bool WorkRelated { get; set; }
        [Required]
        public ReferenceDataItem PrimaryDesc { get; set; }
        [Required]
        public string OtherPrimaryType { get; set; }
        [Required]
        public string DescriptionLocal { get; set; }
        public string DescriptionEnglish { get; set; }
        [Required]
        public string ActionTakenLocal { get; set; }
        public bool ActionTakenEnglish { get; set; }
        [Required]
        public ReferenceDataItem ActualLoss { get; set; }
        [Required]
        public ReferenceDataItem PotentialLoss{ get; set; }

        [Required]
        public ReferenceDataItem AtFaultId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public string Location { get; set; }
        public string Area { get; set; }
        public string BusinessUnit { get; set; }
        public string BusinessStream { get; set; }
        [Required]
        public ReferenceDataItem LocationType { get; set; }

        //[Required] if locationtype is project
        public ReferenceDataItem ProjectPhaseId { get; set; }
        public string LocationDescription { get; set; }
        public string InvolvedPersonName { get; set; }
        public string InvolvedPersonJob { get; set; }
        //public bool Attachments { get; set; }
    }
}