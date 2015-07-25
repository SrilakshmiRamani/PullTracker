using System.Web.Mvc;
using Autofac;
using PullTracker.Common;
using PullTracker.Repository;

namespace PullTracker.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class OpenBranchController : Controller
    {
        private readonly IPullTrackerRepository _pullRepository;

        public OpenBranchController()
        {
            _pullRepository = AutofacHelper.Scope.Resolve<IPullTrackerRepository>();
        }

        public OpenBranchController(IPullTrackerRepository pullRepository)
        {
            this._pullRepository = pullRepository;
        }

        public ActionResult Index()
        {
            var response = Json(_pullRepository.GetOpenBranches(), JsonRequestBehavior.AllowGet);

            return response;

        }

    }
}
