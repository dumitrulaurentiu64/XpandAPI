
using XPandAuthentication.Dtos;
using XPandAuthentication.Model;

namespace XPandAuthentication.Repositories
{
    public interface IAuthRepository
    {
        public User Login(LoginDto dto);
        public User GetUser(int userId);
        public void Register(RegisterDto dto);
    }
}
