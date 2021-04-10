using DevFramewok.NorthWind.Business.Abstract;
using DevFramewok.NorthWind.Business.Concreate.Managers;
using DevFramewok.NorthWind.Business.DependencyResolvers.Ninject;
using DevFramework.NorthWind.DataAccess.Concreate.EntityFramework;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService: IProductService //Business aynen çağırıyoruz böylece arayüz servis üzerinden gelmiş oluyor , business wcf nin arkasında durmuş oluyor
{
    //SOAH da genelde  parametreli yapılandıırıcı kullanılmaz 
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //

     
    }
    // ProductManager productManager=new ProductManager(new EfProductDal(),new AutoMapperMapper()) --container üzerinden yapılacak o üzden kapatıldı --Managerin soyutu
    IProductService _productService = InstanceFactoriy.GetInstance<IProductService>();
    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransactionalOperations(Product product1, Product product2)
    {
         _productService.TransactionalOperations(product1, product2); //Transaction aspectleri test etmek için yazılmıştı 
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }
}