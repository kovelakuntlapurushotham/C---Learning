using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DTOs;
using UserManagement.Models;
using UserManagement.Repositories;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _service;

        public UserManagementController(IUserManagementService service)
        {

            this._service = service;
        }

        [HttpPost("login")]

        public async Task<ApiResponse<LoginResponseDto>> ValidateUser([FromQuery] LoginRequestDto loginRequest)
        {
            return await _service.Login(loginRequest);
        }

        [HttpGet("greet")]

        public string SendMessage(string message)
        {
            return _service.test(message);
        }

        [HttpGet("getUsers")]
        [Authorize]

        public async Task<ApiResponse<List<UserDto>>> GetUser()
        {
            return await _service.GetUsers();
        }
    }
}
