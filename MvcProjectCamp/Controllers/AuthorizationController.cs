using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        private AdminManager _adminManager = new AdminManager(new EfAdminDal());
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
            var categoryValue = _adminManager.GetById(id);
            return View(categoryValue);
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
