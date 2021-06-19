using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class DefaultController : Controller
    {
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Headings()
        {
            var headingList = _headingManager.GetAll();
            return View(headingList);
        }
    }
}