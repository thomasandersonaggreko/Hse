namespace Data
{
    using Contracts;

    using HSEModel.Projections;

    using MongoDB.Bson.Serialization;

    /// <summary>
    /// The no sql startup.
    /// </summary>
    public class NoSqlStartup : IStartup
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            BsonClassMap.RegisterClassMap<ReportListItemProjection>(
                cm =>
                    {
                        cm.MapMember(c => c.Id);
                        cm.MapMember(c => c.ReportedByName);
                        cm.MapMember(c => c.IncidentType);
                        cm.MapMember(c => c.ReferenceNumber);
                        cm.MapMember(c => c.CreatedBy);
                        cm.MapMember(c => c.Created);
                        cm.MapMember(c => c.LastUpdated);
                        cm.MapMember(c => c.LastUpdatedBy);
                    });
        }
    }
}