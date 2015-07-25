using System.Web.Mvc;
using Autofac;
using PullTracker.Common;
using PullTracker.Repository;

namespace PullTracker.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class OpenRequestController : Controller
    {

        private readonly IPullTrackerRepository _pullRepository;

        public OpenRequestController()
        {
            _pullRepository = AutofacHelper.Scope.Resolve<IPullTrackerRepository>();
        }

        public OpenRequestController(IPullTrackerRepository pullRepository)
        {
            this._pullRepository = pullRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = Json(_pullRepository.GetOpenPullRequests(), JsonRequestBehavior.AllowGet);

            return response;

        }

    }
}
