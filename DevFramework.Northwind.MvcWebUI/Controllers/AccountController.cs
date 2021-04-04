using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            //Normal şartlarda önce kullanıcı db de var mı diye kontrol etmek  lazım
            AuthenticationHelper.CreateAuthCookie(new Guid(),  
                "kubrapetek", 
                "kubrapetek@gmail.com", 
                DateTime.Now.AddDays(15),
                new[] { "Admin" },
                false, 
                "Kubra",
                "Petek");
            return "User is authenticated!";
        }
    }
}