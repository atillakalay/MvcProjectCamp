using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        private ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string searchedWord)
        {
            var searchedWords = _contentManager.GetSearchedWords(searchedWord);

            if (!string.IsNullOrEmpty(searchedWord))
            {
                return View(searchedWords);
            }

            return View(_contentManager.GetAll());

        }

        public ActionResult ContentByHeading(int id)
        {
            var result = _contentManager.GetListById(id);
            return View(result);
        }
    }
}