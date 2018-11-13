using AutoMapper;
using LearningSystem.Domain.Entity;
using LearningSystem.Domain.View;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningSystem.App
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
                expression.CreateMap<RegisterStudentViewModel, Student>());
        }
    }
}
