using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using Newtonsoft.Json.Linq;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            EfContext context = new EfContext();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
                                                                   x.AdminPassword == result);


            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }

            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
            return View();

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
          
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = writer.WriterPassword;
            string results = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterPassword = results;

            EfContext context = new EfContext();
            var writerUserInfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
                                                                     x.WriterPassword == results);
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LfQczwbAAAAALfDCFJZaWrksASvI4BJOSm5FKUD";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");


            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
            return View();
        }
    }
}
