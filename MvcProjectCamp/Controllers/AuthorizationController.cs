using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        private AdminManager _adminManager = new AdminManager(new EfAdminDal());
        private RoleManager _roleManager = new RoleManager(new EfRoleDal());

        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var admins = _adminManager.GetAll();
            return View(admins);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Admin admin)
        {
            _adminManager.Add(admin);
            return RedirectToAction("Index", "Authorization");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> adminRole = (from c in _roleManager.GetAll()
                select new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()

                }).ToList();

            ViewBag.valueadmin = adminRole;

            var adminValue = _adminManager.GetById(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            _adminManager.Update(admin);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var adminValue = _adminManager.GetById(id);
            if (adminValue.AdminStatus == true)
            {
                adminValue.AdminStatus = false;
            }
            else
            {
                adminValue.AdminStatus = true;
            }
            _adminManager.Delete(adminValue);
            return RedirectToAction("Index");
        }
    }
}
