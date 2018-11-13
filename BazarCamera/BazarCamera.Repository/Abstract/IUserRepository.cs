using BazarCamera.Domain.Entity;
using BazarCamera.Domain.View;
using System.Collections.Generic;

namespace BazarCamera.Repository.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        bool Register(RegisterUserVm vm);
        void LoginUser(LoginVm vm, string sessionId);
    }
}