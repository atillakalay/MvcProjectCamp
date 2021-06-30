using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        private AdminManager _adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var admins = _adminManager.GetAll();
            return View(admins);
        }
    }
}
