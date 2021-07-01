using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Concrete.EntityFramework;
using MvcProjectCamp.Models;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        private EfContext _context = new EfContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 9
            });
            return categoryClasses;
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }
        public ActionResult CategoryColumnChart()
        {
            return View();
        }
        public ActionResult CategoryLineChart()
        {
            return View();
        }

        public List<CategoryClass> CategoryListChart()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            using (var _context = new EfContext())
            {
                categoryClasses = _context.Categories.Select(x => new CategoryClass
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.CategoryName.Length
                }).ToList();
            }

            return categoryClasses;
        }

        public ActionResult VisualizeByCategory()
        {
            return Json(CategoryListChart(), JsonRequestBehavior.AllowGet);
        }
    }


}