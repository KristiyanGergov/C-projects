using LearningSystem.App.Infrastructure.Abstract;
using System.Security.Principal;
using System.Web.Security;
using System;

namespace LearningSystem.App.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}