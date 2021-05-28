using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private ContactManager _contactManager = new ContactManager(new EfContactDal());
        private ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var result = _contactManager.GetAll();
            return View(result);
        }

        public ActionResult GetContactDetails(int id)
        {
            var result = _contactManager.GetById(id);
            return View(result);
        }

        public PartialViewResult ContactMenu()
        {
            return PartialView();
        }
    }
}