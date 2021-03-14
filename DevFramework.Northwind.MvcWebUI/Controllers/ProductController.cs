using DevFramewok.NorthWind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            //return View(_productService.GetAll()); --bunu asla yapma//viewback ve viewData kullamak zorunda kalabiliriz

            var model = new ProductListViewModel
            {
                Products=_productService.GetAll()
            };

            return View(model);
        }
        public string Add()
        {
            _productService.Add(new NorthWind.Entities.Concreate.Product
            {
                CategoryId = 1,
                ProductName = "GSM",
                QuantityPerUnit = "1",
                UnitPrice = 12
            });
                
            return "Added";
        }
    }
}