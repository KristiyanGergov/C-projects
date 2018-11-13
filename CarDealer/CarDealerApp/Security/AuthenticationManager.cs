namespace CarDealerApp.Security
{
    using CarDealer.Data;
    using CarDealer.Models.EntityModels;
    using System.Linq;
    public class AuthenticationManager
    {
        private static CarDealerContext context = new CarDealerContext();
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
            var firstOrDefault = context.Logins.FirstOrDefault(login => login.SessionId == sessionId & login.IsActive);
            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.User;
                if (authenticatedUser != null)
                    return authenticatedUser;
            }
            return null;
        }
    }
}