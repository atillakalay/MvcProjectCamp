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
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private ContactManager _contactManager = new ContactManager(new EfContactDal());
        
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
        public PartialViewResult ContactSideBarPartial()
        {
            string userEmail = (string)Session["WriterMail"];
            var contactList = _contactManager.GetAll();
            ViewBag.contactCount = contactList.Count();
            var listResult = _messageManager.GetListSendbox(userEmail);
            var sendList = listResult.FindAll(x => x.isDraft == false);
            ViewBag.sendCount = sendList.Count();
            var listResult2 = _messageManager.GetListInbox(userEmail);
            ViewBag.inboxCount = listResult2.Count();
            var drafList = listResult.FindAll(x => x.isDraft == true);
            ViewBag.draftCount = drafList.Count();
            return PartialView();
        }
    }
}