using System.Linq;
using System.Web.Mvc;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        private EfContext _efContext = new EfContext();
        // GET: Statistics
        public ActionResult Index()
        {
            var value1 = _efContext.Categories.Count().ToString();
            ViewBag.value1 = value1;

            var value2 = _efContext.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.value2 = value2;

            //var value3 = (from x in _efContext.Writers select x.WriterName.StartsWith("A") || x.WriterName.EndsWith("K")).Distinct().Count().ToString();
            var value3 = (from x in _efContext.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.value3 = value3;

            var value4 = _efContext.Categories.Where(u => u.CategoryId == _efContext.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.value4 = value4;

            var value5 = _efContext.Categories.Count(x => x.CategoryStatus == true) - _efContext.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.value5 = value5;

            return View();
        }
    }
}