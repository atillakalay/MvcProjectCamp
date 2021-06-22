using System;

using System.Linq;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private ContactManager _contactManager = new ContactManager(new EfContactDal());
        private MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string userEmail = (string)Session["WriterMail"];
            var result = _messageManager.GetListInbox(userEmail);
            return View(result);
        }
        public ActionResult SendBox()
        {
            string userEmail = (string)Session["WriterMail"];
            var result = _messageManager.GetListSendbox(userEmail);
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
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var result = _messageManager.GetById(id);
            return View(result);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var result = _messageManager.GetById(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string button)
        {
            string userEmail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(message);
            if (button == "draft")
            {

                results = messageValidator.Validate(message);
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = userEmail;
                    message.isDraft = true;
                    _messageManager.Add(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                results = messageValidator.Validate(message);
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Now;
                    message.SenderMail = userEmail;
                    message.isDraft = false;
                    _messageManager.Add(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
        public ActionResult Draft()
        {
            string userEmail = (string)Session["WriterMail"];
            var sendList = _messageManager.GetListSendbox(userEmail);
            var draftList = sendList.FindAll(x => x.isDraft == true);
            return View(draftList);
        }

        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = _messageManager.GetById(id);
            return View(Values);
        }
    }
}