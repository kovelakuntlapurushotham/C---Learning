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
        private readonly IJwtTokenGenerator _jwtTokenService;

        public UserManagementService(UserManagementContext db, IMapper mapper, IJwtTokenGenerator jwtTokenService)
        {
            _db = db;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ApiResponse<List<UserDto>>> GetUsers()
        {
            var user =  await _db.Users.ToListAsync();

            if (user == null)
            {
                return new ApiResponse<List<UserDto>>(false, "User Not Found", 404, new List<UserDto>());
            }
            var userDto = _mapper.Map<List<UserDto>>(user);

            return new ApiResponse<List<UserDto>>(true, "User Found", 200, userDto);  

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
                Token = _jwtTokenService.GenerateToken(isUserExits),
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
