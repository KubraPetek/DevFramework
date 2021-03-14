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
    }
}