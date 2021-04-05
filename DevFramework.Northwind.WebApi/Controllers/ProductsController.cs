using DevFramewok.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        //Web api entegrasyonu 
        //Api yazıyorsak sadece api ile ilgili kodlar olmalı
        //Tüm katmanlar yanlızca kendini ilgilendiren kodları içermeli 
        //Burası servis katmanı --işlemleri business üzerinden yürütmek gerekiyor

        private IProductService _productService;  //Business tan çekerek dependecy injection yapmış olduk 
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public ProductsController() //Parametresiz yapılandırıcı olmazsa api çağrıldığında hata veriyor
        {

        }
        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
