using DevFramewok.NorthWind.Business.Abstract;
using DevFramewok.NorthWind.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.PostSharp;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Core.DataAccess;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.Concreate.Managers
{
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
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
           // _queryable.Table()
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);

        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
