using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.Abstract
{
    [ServiceContract] //WCF için eklendi 
    public interface IProductService
    {
        [OperationContract]  //WCF için eklendi 
        List<Product> GetAll();
        [OperationContract] 
        Product GetById(int id);
        [OperationContract]  
        Product Add(Product product);
        [OperationContract]  
        Product Update(Product product);
        [OperationContract]  
        void TransactionalOperations(Product product1, Product product2);
    }
}
