namespace BazarCamera.App.Security.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
