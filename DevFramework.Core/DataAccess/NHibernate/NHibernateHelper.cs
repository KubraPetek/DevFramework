using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract  class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory; //Hngi db den geliyorsa ona göre bir session döndürür
       
        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); } //null ise biz oluşturruz 
        }
        protected abstract ISessionFactory InitializeFactory(); //nerden geliyorsa oranın iplament etmesini sağlar

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
