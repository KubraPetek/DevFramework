using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DevFramework.Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token!=null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);

                    string[] tokenValues = decodedString.Split(':');

                    if (tokenValues[0]=="kubra"&&tokenValues[1]=="12345")// TODO : Burayı sonradan db den kontrol etmek gerekecek
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), new[] { "Admin" });
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal; //Web api için yapıldı
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}