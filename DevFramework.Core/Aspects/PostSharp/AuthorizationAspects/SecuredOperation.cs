using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            foreach (var item in roles)
            {
                if (!System.Threading.Thread.CurrentPrincipal.IsInRole(item)) //CurrentPrincipal ;bağımsız, kullanıcı bilgilerini tutan context 
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized==false)
            {
                throw new SecurityException("You are not authorized.");
            }
        }

    }
}
