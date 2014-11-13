using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SH.BAL;

namespace SH.UI
{
    public class SHDependencyResolver : IDependencyResolver
    {
        IKernel kernel;

        public SHDependencyResolver()
        {
            kernel = new StandardKernel(new StorageNinjectModule(), new RepositoryNinjectModule());
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}