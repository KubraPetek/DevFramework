using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramewok.NorthWind.Business.Concreate.Managers;
using DevFramework.NorthWind.Entities.Concreate;
using FluentValidation;

namespace DevFramework.Business.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ProductManagerTest
    {
        Mock<IProductDal> mock;
        public ProductManagerTest()
        {
            mock = new Mock<IProductDal>();
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ProductValidationCheck()
        {
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
