using System.Web.Mvc;
using System.Web.Routing;

namespace CompanyRegister.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //       name: null,
            //       url: "{name}",
            //       defaults: new { controller = "Employee", action = "Search" }
            //   );
            //routes.MapRoute(
            //    name: "Search",
            //    url: "{controller}/{action}/{name}",
            //    defaults: new { controller = "Employee", action= "All", name = UrlParameter.Optional }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "All", id = UrlParameter.Optional }
            );
        }
    }
}
