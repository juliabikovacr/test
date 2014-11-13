using Ninject.Modules;
using SH.BAL.Storages;
using SH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SH.UI
{
    public class StorageNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IStorage<Hero>>().To<HeroStorage>();
            Bind<IStorage<Studio>>().To<StudioStorage>();
        }
    }
}