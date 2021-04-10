using DevFramewok.NorthWind.Business.Abstract;
using DevFramewok.NorthWind.Business.DependencyResolvers.Ninject;
using DevFramework.NorthWind.Entities.Concreate;
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
            //Postmandan çağırırken header kısmında kullanılan  token burda decode edilip kullanılır. Bu tokeni de base64 formatı ile kullanıcı adı ve sifreden oluşturabiliriz 
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token!=null)
                { 
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);

                    string[] tokenValues = decodedString.Split(':');
                    IUserService userService = InstanceFactoriy.GetInstance<IUserService>(); //InstanceFactory de oluşturulacak --UserManager verecek Bind durumundan dolayı

                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);

                    if (user!=null)// artık db den kontrol ediyoruz 
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]),userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray());
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