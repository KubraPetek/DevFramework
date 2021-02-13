using DevFramework.Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
    public interface IQueryaleRepository<T> where T:class,IEntity,new()
    {
        IQueryable<T> Table { get; }
    }
}
