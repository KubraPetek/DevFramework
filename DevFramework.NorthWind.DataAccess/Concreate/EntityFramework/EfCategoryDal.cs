using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Concreate.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {

    }
}
