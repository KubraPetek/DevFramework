using DevFramewok.NorthWind.Business.Abstract;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.Concreate.Managers
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public User GetByUserNameAndPassword(string userName, string password)
        {
           return _userDal.Get(u => u.UserName == userName & u.Password == password);
        }
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
    }
}
