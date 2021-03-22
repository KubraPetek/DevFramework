using DevFramewok.NorthWind.Business.Abstract;
using DevFramewok.NorthWind.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.PostSharp.AuthorizationAspects;
using DevFramework.Core.Aspects.PostSharp.CacheAspects;
using DevFramework.Core.Aspects.PostSharp.LogAspects;
using DevFramework.Core.Aspects.PostSharp.PerformanceAspect;
using DevFramework.Core.Aspects.PostSharp.TransactionAspects;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DevFramewok.NorthWind.Business.Concreate.Managers
{
   // [LogAspect(typeof(FileLogger))]//Classtaki tüm metotlar loglanacaktır  //yada tüm managerların loglanması için Assambly info içinde bu tanımı yazabiliriz 
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        //private IQueryaleRepository<Product> _queryable;
        public ProductManager(IProductDal productDal)
        {
            //(IProductDal productDal, IQueryaleRepository<Product> queryable)
            //_queryable = queryable;
            _productDal = productDal;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager), 120)]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceCounterAspect(2)]//bu metodun çalışması 2 saniyeyi geçerse log tutcak
        [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
        {
            // _queryable.Table()
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);

        }
        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperations(Product product1, Product product2)
        {
            //using(TransactionScope scope=new TransactionScope())
            //{
            //    try
            //    {
            //        _productDal.Add(product1);
            //        //Business Codes
            //        _productDal.Update(product2);
            //        scope.Complete();

            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        scope.Dispose();
            //    }
            //}
            _productDal.Add(product1);
            _productDal.Update(product2);

        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
