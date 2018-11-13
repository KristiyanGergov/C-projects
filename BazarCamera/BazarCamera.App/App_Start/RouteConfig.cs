using System.Web.Mvc;
using System.Web.Routing;

namespace BazarCamera.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    name: null,
                    url: "{camera}",
                    defaults: new { controller = "Camera", action = "Search" }
                );

            routes.MapRoute(
                    name: "Search",
                    url: "{controller}/{action}/{camera}",
                    defaults: new { controller = "Camera", action = "All", camera = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Camera", action = "All", id = UrlParameter.Optional }
            );
        }
    }
}
