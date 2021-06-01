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
    public class MessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());

        // GET: Message
        public ActionResult Inbox()
        {
            var result = _messageManager.GetListInbox();
            return View(result);
        }

        public ActionResult SendBox()
        {
            var result = _messageManager.GetListSendbox();
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            return View();
        }

    }
}