using System.Web.Mvc;
using System.Web.Routing;

namespace PullTracker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Open Branches",
                url: "PullRequest/OpenBranch",
                defaults: new { controller = "OpenBranch", action = "Index" }
                );

            routes.MapRoute(
                name: "Open Pull Request",
                url: "PullRequest/Open",
                defaults: new { controller = "OpenRequest", action = "Index" }
                );

            routes.MapRoute(
                name: "Merge Ready Pull Request",
                url: "PullRequest/MergeReady",
                defaults: new { controller = "MergeReady", action = "Index" }
                );

            routes.MapRoute(
                name: "All Pull Request",
                url: "PullRequest/{*catchall}",
                defaults: new { controller = "PullRequest", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}