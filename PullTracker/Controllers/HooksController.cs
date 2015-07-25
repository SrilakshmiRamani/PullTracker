using System.Web.Mvc;
using Autofac;
using PullTracker.Common;
using PullTracker.Repository;

namespace PullTracker.Controllers
{
    public class HooksController : Controller
    {
        private readonly IPullTrackerRepository _pullRepository;

        public HooksController()
        {
            _pullRepository = AutofacHelper.Scope.Resolve<IPullTrackerRepository>();
        }

        public HooksController(IPullTrackerRepository pullRepository)
        {
            this._pullRepository = pullRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = Json(_pullRepository.GetHooks(), JsonRequestBehavior.AllowGet);

            return response;

        }

    }
}
