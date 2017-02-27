namespace Contracts
{
    using System;

    public abstract class DomainObject
    {
        public int Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}