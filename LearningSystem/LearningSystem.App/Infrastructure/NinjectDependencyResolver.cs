using LearningSystem.App.Concrete;
using LearningSystem.App.Infrastructure.Abstract;
using LearningSystem.App.Infrastructure.Concrete;
using LearningSystem.Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningSystem.App.Infrastructure
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
            this.kernel.Bind<IStudentRepository>().To<StudentRepository>();
            this.kernel.Bind<ICourseRepository>().To<CourseRepository>();
            this.kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
            this.kernel.Bind<ILoginRepository>().To<LoginRepository>();
        }

    }
}