using DevFramework.Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.Entities.Concreate
{
    public class Category:IEntity
    {
        public virtual  int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
