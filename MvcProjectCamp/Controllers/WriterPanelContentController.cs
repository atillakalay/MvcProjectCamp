using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(int id)
        {
            var result = _contentManager.GetAllByWriter();
            return View(result);
        }
    }
}