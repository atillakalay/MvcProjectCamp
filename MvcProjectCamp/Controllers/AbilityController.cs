using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class AbilityController : Controller
    {
        private AbilityManager abilityManager = new AbilityManager(new EfAbilityDal());
        public ActionResult Index()
        {
            var abilities = abilityManager.GetAll();
            return View(abilities);
        }
    }
}