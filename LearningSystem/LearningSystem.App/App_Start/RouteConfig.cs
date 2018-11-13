using System.Web.Mvc;
using System.Web.Routing;

namespace LearningSystem.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: null,
                url: "{courseName}",
                defaults: new { controller = "Course", action = "Search" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Course", action = "All", id = UrlParameter.Optional }
            );
        }

    }
}