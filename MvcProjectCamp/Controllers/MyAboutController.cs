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
    public class MyAboutController : Controller
    {
        // GET: MyAbout
        private MyAboutManager myAboutManager = new MyAboutManager(new EfMyAboutDal());
        public ActionResult Index()
        {
            var result = myAboutManager.GetAll();
            return View(result);
        }
    }
}