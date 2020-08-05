using System.Web.Mvc;

namespace Tests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult CreateTest() => View();

        public ActionResult PassTheTest(int? id)
        {
            ActionResult result = HttpNotFound("wrong id");

            if (id.HasValue)
            {
                ViewBag.testId = id;
                result = View();
            }

            return result;
        }
    }
}
