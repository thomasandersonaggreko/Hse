namespace HSEModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    /// <summary>
    /// The report.
    /// </summary>
    public abstract class Report : DomainObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether [action taken english].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [action taken english]; otherwise, <c>false</c>.
        /// </value>
        public bool ActionTakenEnglish { get; set; }

        /// <summary>
        /// Gets or sets the action taken local.
        /// </summary>
        /// <value>
        /// The action taken local.
        /// </value>
        [Required]
        public string ActionTakenLocal { get; set; }

        /// <summary>
        /// Gets or sets the actual loss.
        /// </summary>
        /// <value>
        /// The actual loss.
        /// </value>
        [Required]
        public ReferenceDataItem ActualLoss { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets at fault identifier.
        /// </summary>
        /// <value>
        /// At fault identifier.
        /// </value>
        [Required]
        public ReferenceDataItem AtFaultId { get; set; }

        /// <summary>
        /// Gets or sets the business stream.
        /// </summary>
        /// <value>
        /// The business stream.
        /// </value>
        public string BusinessStream { get; set; }

        /// <summary>
        /// Gets or sets the business unit.
        /// </summary>
        /// <value>
        /// The business unit.
        /// </value>
        public string BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the description english.
        /// </summary>
        /// <value>
        /// The description english.
        /// </value>
        public string DescriptionEnglish { get; set; }

        /// <summary>
        /// Gets or sets the description local.
        /// </summary>
        /// <value>
        /// The description local.
        /// </value>
        [Required]
        public string DescriptionLocal { get; set; }

        /// <summary>
        /// Gets the type of the incident.
        /// </summary>
        /// <value>
        /// The type of the incident.
        /// </value>
        [Required]
        public abstract IncidentType IncidentType { get; }

        /// <summary>
        /// Gets or sets the involved person job.
        /// </summary>
        /// <value>
        /// The involved person job.
        /// </value>
        public string InvolvedPersonJob { get; set; }

        /// <summary>
        /// Gets or sets the name of the involved person.
        /// </summary>
        /// <value>
        /// The name of the involved person.
        /// </value>
        public string InvolvedPersonName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [Required]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the location description.
        /// </summary>
        /// <value>
        /// The location description.
        /// </value>
        public string LocationDescription { get; set; }

        /// <summary>
        /// Gets or sets the type of the location.
        /// </summary>
        /// <value>
        /// The type of the location.
        /// </value>
        [Required]
        public ReferenceDataItem LocationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the other primary.
        /// </summary>
        /// <value>
        /// The type of the other primary.
        /// </value>
        [Required]
        public string OtherPrimaryType { get; set; }

        /// <summary>
        /// Gets or sets the potential loss.
        /// </summary>
        /// <value>
        /// The potential loss.
        /// </value>
        [Required]
        public ReferenceDataItem PotentialLoss { get; set; }

        /// <summary>
        /// Gets or sets the primary desc.
        /// </summary>
        /// <value>
        /// The primary desc.
        /// </value>
        [Required]
        public ReferenceDataItem PrimaryDesc { get; set; }
      
        /// <summary>
        /// Gets or sets the project phase identifier.
        /// </summary>
        /// <value>
        /// The project phase identifier.
        /// </value>
        public ReferenceDataItem ProjectPhaseId { get; set; }

        /// <summary>
        /// Gets or sets the report date.
        /// </summary>
        /// <value>
        /// The report date.
        /// </value>
        [Required]
        public DateTime ReportDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the reported by.
        /// </summary>
        /// <value>
        /// The name of the reported by.
        /// </value>
        public string ReportedByName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [work related].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [work related]; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool WorkRelated { get; set; }

        // public bool Attachments { get; set; }
    }
}