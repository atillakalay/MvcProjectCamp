using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        // GET: Abour
        public ActionResult Index()
        {
            return View();
        }
    }
}