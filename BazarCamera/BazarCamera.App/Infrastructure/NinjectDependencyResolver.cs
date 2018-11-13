using BazarCamera.App.Security.Abstract;
using BazarCamera.App.Security.Concrete;
using BazarCamera.Repository;
using BazarCamera.Repository.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BazarCamera.App.Infrastructure
{
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
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<ICameraRepository>().To<CameraRepository>();
            this.kernel.Bind<IUserRepository>().To<UserRepository>();
            this.kernel.Bind<IAuthProvider>().To<AuthProvider>();
        }
    }
}