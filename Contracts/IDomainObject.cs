namespace Contracts
{
    using System;

    public abstract class DomainObject
    {
        public string Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}