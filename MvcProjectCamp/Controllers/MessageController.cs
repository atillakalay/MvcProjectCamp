using System;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator messageValidator = new MessageValidator();

        // GET: Message
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
            ValidationResult results = messageValidator.Validate(message);
            if (button == "draft")
            {

                results = messageValidator.Validate(message);
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = "admin@gmail.com";
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
                    message.SenderMail = "admin@gmail.com";
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

        public ActionResult IsRead(int id)
        {
            var result = _messageManager.GetById(id);
            if (result.IsRead == true)
            {
                result.IsRead = false;
            }
            _messageManager.Update(result);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            var readMessage = _messageManager.GetAll(x => x.IsRead == true);
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            var unReadMessage = _messageManager.GetAll(x=>x.ReceiverMail=="admin@gmail.com"&&x.IsRead==false);
            return View(unReadMessage);
        }
    }
}