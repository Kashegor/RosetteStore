using Moq;
using Ninject.Modules;
using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Concrete;
using RosetteStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosetteStore.WebUI.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRosetteRepository>().To<EFRosetteRepository>();
        }

    }
}