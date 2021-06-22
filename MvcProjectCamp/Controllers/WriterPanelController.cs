using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using PagedList;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
        private EfContext _efContext = new EfContext();
        [HttpGet]
        public ActionResult WriterProfile()
        {
            string result = (string)Session["WriterMail"];
            var writerIdInfo = _efContext.Writers.Where(w => w.WriterMail == result).Select(x => x.WriterId).FirstOrDefault();
            var writerValue = _writerManager.GetById(writerIdInfo);
            ViewBag.d = writerIdInfo;
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                _writerManager.Update(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult HeadingByWriter(string email)
        {
            email = (string)Session["WriterMail"];
            var writerIdInfo = _efContext.Writers.Where(x => x.WriterMail == email).Select(z => z.WriterId).FirstOrDefault();
            var values = _headingManager.GetListByWriter(writerIdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string email = (string)Session["WriterMail"];
            var writerIdInfo = _efContext.Writers.Where(x => x.WriterMail == email).Select(z => z.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            heading.HeadingStatus = true;
            _headingManager.Add(heading);
            return RedirectToAction("NewHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;

            var headingValue = _headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.Update(heading);
            return RedirectToAction("HeadingByWriter", "WriterPanel");
        }
        public ActionResult Delete(int id)
        {
            var headingValue = _headingManager.GetById(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            _headingManager.Delete(headingValue);
            return RedirectToAction("HeadingByWriter");
        }

        public ActionResult AllHeading(int pageNumber = 1)
        {
            var headingList = _headingManager.GetAll().ToPagedList(pageNumber, 4);
            return View(headingList);
        }

    }
}