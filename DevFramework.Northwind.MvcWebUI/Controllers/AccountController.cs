using DevFramewok.NorthWind.Business.Abstract;
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
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public string Login(string userName,string password)//Bunları query string ile almak gerekecek
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user!= null)
            {
                //Normal şartlarda önce kullanıcı db de var mı diye kontrol etmek  lazım
                AuthenticationHelper.CreateAuthCookie(new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray(),
                    false,
                    user.FirstName,
                    user.LastName);
                return "User is authenticated!";
            }
            return "User is not authenticated!";

        }
    }
}