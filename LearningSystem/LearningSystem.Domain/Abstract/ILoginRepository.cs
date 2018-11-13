using LearningSystem.Domain.Bind;
using LearningSystem.Domain.Entity;
using LearningSystem.Domain.View;
using System.Collections.Generic;

namespace LearningSystem.Domain.Abstract
{
    public interface ILoginRepository
    {
        IEnumerable<Login> Logins { get; }
        bool Register(RegisterStudentViewModel student);
        void LoginUser(LoginStudentBm bind, string sessionId);
    }
}
