using LearningSystem.App.Concrete;
using LearningSystem.Domain.Entity;
using System.Linq;

namespace LearningSystem.App.Security
{
    public class AuthenticationManager
    {
        private static LearningSystemContext context = new LearningSystemContext();
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

        public static Student GetAuthenticatedUser(string sessionId)
        {
            var firstOrDefault = context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive);
            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.Student;
                if (authenticatedUser != null)
                    return authenticatedUser;
            }

            return null;
        }
    }
}