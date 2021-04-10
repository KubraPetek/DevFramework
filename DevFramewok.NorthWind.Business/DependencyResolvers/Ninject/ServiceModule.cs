using DevFramewok.NorthWind.Business.Abstract;
using DevFramework.Core.Utulities.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.DependencyResolvers.Ninject
{
   public  class ServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());

        }
    }
}
