using DevFramework.NorthWind.DataAccess.Concreate.NHibernate;
using DevFramework.NorthWind.DataAccess.Concreate.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameters_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.IsTrue(result.Count > 0);
        }
    }
}
