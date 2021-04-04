using DevFramework.NorthWind.DataAccess.Concreate.EntityFramework.Mappings;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Concreate.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);//kod tarafından db oluşturulmasını engeleyecektir
            //Burda Hazır db den çekeceğimiz için datayı bu yolu kullandık
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } //Bunların mappinglerini yapmayı unutma , yapılması çünkü
        public DbSet<Role> Role { get; set; }//Bunların mappinglerini yapmayı unutma , yapılması çünkü   --İsimler tablo ile aynı olduğu için egrek olmaayabilir

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            //mapping implemantasyonu
        }
    }
}
