using CompanyRegister.App.Infrastructure.Abstract;
using CompanyRegister.App.Infrastructure.Concrete;
using CompanyRegister.Repositories;
using CompanyRegister.Repositories.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CompanyRegister.App.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            this.kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            this.kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }


    }
}