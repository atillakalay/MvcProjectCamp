using System.Linq;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        private EfContext _efContext = new EfContext();
        public ActionResult MyContent(string result)
        {
            result = (string)Session["WriterMail"];
            var writerIdInfo = _efContext.Writers.Where(w => w.WriterMail == result).Select(x => x.WriterId).FirstOrDefault();
            var contentValues = _contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}