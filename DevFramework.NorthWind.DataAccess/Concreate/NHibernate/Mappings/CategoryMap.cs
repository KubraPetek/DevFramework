﻿using DevFramework.NorthWind.Entities.Concreate;
using FluentNHibernate.Mapping;

namespace DevFramework.NorthWind.DataAccess.Concreate.NHibernate.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");

        }
    }
}
