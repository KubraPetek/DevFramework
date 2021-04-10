using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.DependencyResolvers.Ninject
{
    //Ninject bağımlı bir instance factory 
    public class InstanceFactoriy
    {
        public static  T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule(),new AutoMapperModule());
            return kernel.Get<T>();
        }
    }
}
