namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.EntityModels;
    using System.Linq;
    public class UsersService : Service
    {
        public void RegisterUser(RegisterUserBm bind)
        {
            User user = Mapper.Map<RegisterUserBm, User>(bind);
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }
        public void LoginUser(LoginUserBm bind, string sessionId)
        {
            if (!this.Context.Logins.Any(t => t.SessionId == sessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionId });
                this.Context.SaveChanges();
            }

            Login myLogin = this.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId);
            myLogin.IsActive = true;
            User model = this.Context.Users.FirstOrDefault(user => user.Username == bind.Username && user.Password == bind.Password);

            myLogin.User = model;
            this.Context.SaveChanges();
        }
        public bool UserExists(LoginUserBm bind)
        {
            if (this.Context.Users.Any(t => t.Username == bind.Username && t.Password == bind.Password))
            {
                return true;
            }
            return false;
        }
    }
}