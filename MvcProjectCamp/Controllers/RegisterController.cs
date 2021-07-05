using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;

namespace MvcProjectCamp.Controllers
{
    public class RegisterController : Controller
    {
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        // GET: Register
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
            admin.AdminRole = "A";
            _adminManager.Add(admin);
            return RedirectToAction("Index", "Login");
        }
    }
}