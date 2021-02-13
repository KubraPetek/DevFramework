using DevFramework.NorthWind.Entities.Concreate;
using FluentNHibernate.Mapping;

namespace DevFramework.NorthWind.DataAccess.Concreate.NHibernate.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductId).Column("ProductID");
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");


        }
    }
}
