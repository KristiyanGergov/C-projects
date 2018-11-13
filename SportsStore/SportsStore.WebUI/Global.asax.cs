﻿namespace SportsStore.WebUI
{
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Infrastructure.Binders;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

        }
    }
}
