using UserManagement.DTOs;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public interface IUserManagementService
    {
        Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);

        string test(string message);

        Task<ApiResponse<List<UserDto>>> GetUsers();
    }
}
