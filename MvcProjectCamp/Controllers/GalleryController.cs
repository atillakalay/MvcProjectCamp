using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        private ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var result = imageFileManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = "/Images/" + fileName + expansion;
                imageFileManager.Add(ımageFile);
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}