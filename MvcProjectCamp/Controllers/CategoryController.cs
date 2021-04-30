using System.Web.Mvc;
using Business.Concrete;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = _categoryManager.GetAll();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _categoryManager.Add(category);
            return RedirectToAction("GetCategoryList");

        }
    }
}