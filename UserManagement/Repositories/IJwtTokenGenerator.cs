using UserManagement.Models;

namespace UserManagement.Repositories
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Users user);
    }
}
