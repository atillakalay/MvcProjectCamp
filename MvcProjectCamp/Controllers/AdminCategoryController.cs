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

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var result = _categoryManager.GetAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }


        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = _categoryManager.GetById(id);
            _categoryManager.Delete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = _categoryManager.GetById(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}