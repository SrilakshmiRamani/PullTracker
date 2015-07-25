using System.Web.Mvc;

namespace PullTracker.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class PullRequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
