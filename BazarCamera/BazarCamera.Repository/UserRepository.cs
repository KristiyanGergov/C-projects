using System.Collections.Generic;
using BazarCamera.Repository.Abstract;
using BazarCamera.Domain.Entity;
using AutoMapper;
using BazarCamera.Domain.View;
using System.Linq;

namespace BazarCamera.Repository
{
    public class UserRepository : Repository, IUserRepository
    {
        public IEnumerable<User> Users
        {
            get { return this.Context.Users; }
        }
        public bool Register(RegisterUserVm vm)
        {
            User user = Mapper.Instance.Map<RegisterUserVm, User>(vm);
            if (this.Context.Users.Any(name => name.Username == user.Username))
            {
                return false;
            }
            else
            {
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
                return true;
            }
        }
        public void LoginUser(LoginVm vm, string sessionId)
        {

            if (!this.Context.Logins.Any(login => login.SessionId == sessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionId });
                this.Context.SaveChanges();
            }
            Login myLogin = this.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            myLogin.IsActive = true;
            User model = this.Context.Users.FirstOrDefault(user => user.Username == vm.Username && user.Password == vm.Password);
            myLogin.User = model;
            this.Context.SaveChanges();
        }
    }
}
