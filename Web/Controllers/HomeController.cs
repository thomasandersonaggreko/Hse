using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using System.Threading.Tasks;

    using Business.Commands;
    using Business.Queries;
    using Business.Sdk;

    using HSEModel;
    using HSEModel.Projections;

    using MessageBus;

    public partial class HomeController : Controller
    {
        private IBus bus;

        public HomeController(IBus bus)
        {
            this.bus = bus;
        }
        public virtual async Task<ActionResult> Index()
        {
            ReportListViewQuery query = new ReportListViewQuery();
            query.ExecutingUser = this.User;
            QueryResult<ReportListItemProjection> queryResult = 
                await this.bus.RequestAsync<ReportListViewQuery, QueryResult<ReportListItemProjection>>(query).ConfigureAwait(false);
            return View(MVC.Home.Views.ViewNames.Reports, queryResult.List);
        }

        public virtual async Task<ActionResult> Reports()
        {
            ReportListViewQuery query = new ReportListViewQuery();
            query.ExecutingUser = this.User;
            QueryResult<ReportListItemProjection> queryResult =
                await this.bus.RequestAsync<ReportListViewQuery, QueryResult<ReportListItemProjection>>(query).ConfigureAwait(false);
            return View(queryResult.List);
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