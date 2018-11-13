using System.Collections.Generic;
using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Entity;
using LearningSystem.Domain.View;
using System.Linq;
using AutoMapper;
using LearningSystem.Domain.Bind;

namespace LearningSystem.App.Concrete
{
    public class LoginRepository : Repository, ILoginRepository
    {
        public IEnumerable<Login> Logins => this.Context.Logins;
        public bool Register(RegisterStudentViewModel vm)
        {
            Student student = Mapper.Instance.Map<RegisterStudentViewModel, Student>(vm);
            if (this.Context.Students.Any(name => name.Username == vm.Username))
            {
                return false;
            }
            else
            {
                this.Context.Students.Add(student);
                this.Context.SaveChanges();
                return true;
            }
        }
        public void LoginUser(LoginStudentBm bind, string sessionId)
        {
            if (!this.Context.Logins.Any(login => login.SessionId == sessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionId });
                this.Context.SaveChanges();
            }
            Login mylogin = this.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            mylogin.IsActive = true;
            Student model =
                this.Context.Students.FirstOrDefault(
                    user => user.Username == bind.Username && user.Password == bind.Password);

            mylogin.Student = model;
            this.Context.SaveChanges();
        }
    }


}