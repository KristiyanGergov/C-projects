using BazarCamera.App.Security.Abstract;
using System.Web.Security;

namespace BazarCamera.App.Security.Concrete
{
    public class AuthProvider : IAuthProvider
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