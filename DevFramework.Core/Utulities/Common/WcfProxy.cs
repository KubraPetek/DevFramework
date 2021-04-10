using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utulities.Common
{
    public class WcfProxy<T>
    {
        //servise servis contract üzerinden erişilir 
        //Burda T olarak gönderdiğimiz tip mesela IProductService olabilir
        public static T CreateChannel()
        {
            // servisin abc sinin oluşturulduğu yer
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));
            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<T>(binding,address);

            return channel.CreateChannel();
        }
    }
}
