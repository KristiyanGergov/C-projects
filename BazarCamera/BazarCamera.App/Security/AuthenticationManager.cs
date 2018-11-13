using BazarCamera.Data;
using BazarCamera.Domain.Entity;
using System.Linq;

namespace BazarCamera.App.Security
{
    public class AuthenticationManager
    {
        private static BazarCameraContext context = new BazarCameraContext();

        public static bool IsAuthenticated(string sessionId)
        {
            if (context.Logins.Any(login => login.SessionId == sessionId && login.IsActive))
            {
                return true;
            }
            return false;
        }
        public static void Logout(string sessionId)
        {
            Login login = context.Logins.FirstOrDefault(id => id.SessionId == sessionId);
            login.IsActive = false;
            context.SaveChanges();
        }
        public static User GetAuthenticatedUser(string sessionId)
        {
            var firstOrDefault = context.Logins.FirstOrDefault(log => log.SessionId == sessionId && log.IsActive);
            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.User;
                if (authenticatedUser != null)
                {
                    return authenticatedUser;
                }
            }
            return null;
        }

    }
}