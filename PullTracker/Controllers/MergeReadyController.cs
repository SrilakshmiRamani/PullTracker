using System.Web.Mvc;
using Autofac;
using PullTracker.Common;
using PullTracker.Repository;

namespace PullTracker.Controllers
{
    public class MergeReadyController : Controller
    {

        private readonly IPullTrackerRepository _pullRepository;

        public MergeReadyController()
        {
            _pullRepository = AutofacHelper.Scope.Resolve<IPullTrackerRepository>();
        }

        public MergeReadyController(IPullTrackerRepository pullRepository)
        {
            this._pullRepository = pullRepository;
        }

        public ActionResult Index()
        {
            return Json(_pullRepository.GetMergeReadyPullRequests(), JsonRequestBehavior.AllowGet);

        }

    }
}
