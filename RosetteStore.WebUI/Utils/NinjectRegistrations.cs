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
            //Mock<IRosetteRepository> mock = new Mock<IRosetteRepository>();

            //mock.Setup(m => m.Rosettes).Returns(new List<Rosette>
            //    {
            //        new Rosette { Name = "bg7", Price = 1499 },
            //        new Rosette { Name = "ge4", Price=2299 },
            //        new Rosette { Name = "434gf", Price=899.4M }
            //    });
            //Bind<IRosetteRepository>().ToConstant(mock.Object);

            Bind<IRosetteRepository>().To<EFRosetteRepository>();
        }

    }
}