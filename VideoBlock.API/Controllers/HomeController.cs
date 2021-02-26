using System.Web.Mvc;

namespace VideoBlock.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "VideoBlock";

            return View();
        }
    }
}
