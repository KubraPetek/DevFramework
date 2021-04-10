using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IProductDetailService
/// </summary>

[ServiceContract]
public interface IProductDetailService  // Örnekleme amaçlı yaptık , gerçek implementasyon için IProductService içinde yapıldı 
{

    [OperationContract]  //WCF için eklendi   ---IProduucService de yazmayıp kendi versiyonlarımızı oluşrturmak için kullandık
    List<Product> GetAll();
}