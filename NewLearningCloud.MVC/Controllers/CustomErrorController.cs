using System.Web.Mvc;

namespace NewLearningCloud.MVC.Controllers
{
    public class CustomErrorController : Controller
    {
        public ActionResult Oops()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}