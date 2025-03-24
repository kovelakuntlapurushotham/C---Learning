using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.DTOs;
using UserManagement.Models;
using UserManagement.Repositories;

namespace UserManagement.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManagementContext _db;
        private readonly IMapper _mapper;

        public UserManagementService(UserManagementContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            var isUserExits =  await _db.Users.FirstOrDefaultAsync(user => user.Name.ToLower() == loginRequestDto.UserName.ToLower());
           
            if (isUserExits == null)
            {
                return new ApiResponse<LoginResponseDto>(false, "User Not Found", 404, new LoginResponseDto());
            }
            if(isUserExits?.Password != loginRequestDto.Password)
            {
                return new ApiResponse<LoginResponseDto>(false, "Password invalid", 404, new LoginResponseDto());
            }
            var loginDto = new LoginResponseDto()
            {
                Token = "sdfksdflaksdfjalskdfaslkdfjasl;dkfowefjb;l",
                User = _mapper.Map<UserDto>(isUserExits),

            };

            return new ApiResponse<LoginResponseDto>(true, "Login Successful", 200, loginDto);
        }

        public string test(string message)
        {
            return message;
        }
    }
}
