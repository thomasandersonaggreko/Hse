using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using Business.Commands;
    using Business.Queries;

    using HSEModel.Projections;

    public partial class HomeController : Controller
    {
        private IQueryFactory queryFactory;

        public HomeController(IQueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }
        public virtual ActionResult Index()
        {
            ReportListViewQuery query = this.queryFactory.GetQuery<ReportListViewQuery>();
            QueryResult<ReportListItemProjection> queryResult = query.Execute(this.User);
            return View();
        }

        public virtual ActionResult About()
        {
          
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}