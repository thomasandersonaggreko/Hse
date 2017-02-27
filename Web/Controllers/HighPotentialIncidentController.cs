using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HighPotentialIncidentController : Controller
    {
        // GET: HighPotentialIncident
        public ActionResult CreateRandom()
        {
            return View();
        }
    }
}