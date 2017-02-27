namespace HSEModel
{
    public abstract class Risk
    {
        public bool ActionTakenEnglish { get; set; }

        public bool ActionTakenLocal { get; set; }

        public bool ActionClosed { get; set; }

        public bool Area { get; set; }
        public bool AtFaultId { get; set; }
        public bool Attachments { get; set; }

        public bool BusinessUnit { get; set; }
        public bool BusinessStream { get; set; }
        public bool DescriptionLocal { get; set; }
        public bool DescriptionEnglish { get; set; }

        public bool WorkRelated { get; set; }
        public bool ReportDate { get; set; }

        public bool ReportedByName { get; set; }

        public bool LocationId { get; set; }


        public bool LocationTypeId { get; set; }

        public bool GeneratedById { get; set; }

        public bool RiskRatingAfter { get; set; }
        public bool RiskRatingBefore { get; set; }
        public bool HazardId { get; set; }
        public bool NearMissHazardId { get; set; }
        public bool InvolvedPersonName { get; set; }
        public bool InvolvedPersonJob { get; set; }

        public bool IncidentTypeId { get; set; }

        public bool LocationDescription { get; set; }

        public bool ProjectPhaseId { get; set; }
        public bool OtherHazard { get; set; }

    }
}