namespace Business.Queries
{
    using System.Linq;

    using Contracts;

    public class ReportListViewQuery : GenericQuery<HSEModel.Projections.ReportListItemProjection>
    {
        public ReportListViewQuery(IDatamapper datamapper)
            : base(datamapper)
        {
        }

        public override IQueryable<ReportListItemProjection> RunQuery<ReportListItemProjection>(IDatastore datastore)
        {
            //datastore.Query<ReportListItemProjection>()
            //        .Select<ReportListItemProjection, ReportListItemProjection>(x => x.)

            return from item in datastore.Query<ReportListItemProjection>()
                   select item;
        }
    }
}