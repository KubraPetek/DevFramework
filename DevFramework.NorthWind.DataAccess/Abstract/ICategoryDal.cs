using DevFramework.Core.DataAccess;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {

    }
}
