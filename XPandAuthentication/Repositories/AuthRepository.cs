
using Dapper;
using System.Data;
using System.Data.SqlClient;
using XPandAuthentication.Dtos;
using XPandAuthentication.Model;

namespace XPandAuthentication.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _db;
        public AuthRepository(IConfiguration _configuration)
        {
            this._db = new SqlConnection(_configuration.GetConnectionString("ExplorationAppCon"));
        }

        public User GetUser(int userId)
        {
            string sql = "SELECT * FROM UserAccount where UserID = @userId";
            return this._db.Query<User>(sql, new { userId }).SingleOrDefault();
        }

        public User Login(LoginDto dto)
        {
            User user = this._db.Query<User>("SELECT * FROM UserAccount where Username = @Username", new { dto.Username }).SingleOrDefault();

            return user;
        }

        public void Register(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(dto.UserPassword),
                CaptainID = dto.CaptainID
            };

            string sql = "INSERT INTO UserAccount (Username, UserPassword, Email, CaptainID) VALUES (@Username, @UserPassword, @Email, @CaptainID);";

            this._db.Query<int>(sql, user);
        }
    }
}