using System;
using DevFramework.NorthWind.DataAccess.Concreate.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();
            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameters_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));
            Assert.IsTrue(result.Count>0);
        }
    }
}
