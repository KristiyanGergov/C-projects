namespace SportsStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;
    using Moq;
    using SportsStore.Domain.Entities;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;
    using System.Configuration;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSettings settings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };


            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", settings);
        }


    }
}