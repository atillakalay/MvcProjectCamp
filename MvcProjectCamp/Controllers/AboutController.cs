using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        private AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var result = _aboutManager.GetAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(About about)
        { 
            _aboutManager.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}