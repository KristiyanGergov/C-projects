using AutoMapper;
using BazarCamera.Domain.Entity;
using BazarCamera.Domain.View;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BazarCamera.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void RegisterMaps()
        {
            Mapper.Initialize(expression => {
                expression
                   .CreateMap<RegisterUserVm, User>();
                expression
                   .CreateMap<Camera, CameraVm>();
                expression
                   .CreateMap<CameraVm, Camera>();
               }
            );
        }
    }
}
