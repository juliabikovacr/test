using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SH.DAL.Repositories;
using SH.Models;
using Ninject;
using SH.DAL;

namespace SH.BAL
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Studio>>().To<StudioRepository>();
            Bind<IRepository<Hero>>().To<HeroRepository>();
            Bind<ISHContext>().To<SHContext>().InTransientScope();
        }
    }
}
