using CompanyRegister.App.Infrastructure.Abstract;
using System.Web.Security;

namespace CompanyRegister.App.Infrastructure.Concrete
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