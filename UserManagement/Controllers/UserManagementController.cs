using AutoMapper;
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
        private readonly IUserManagementService service;

        public UserManagementController(IUserManagementService service)
        {

            this.service = service;
        }

        [HttpPost]

        public async Task<ApiResponse<LoginResponseDto>> ValidateUser([FromQuery] LoginRequestDto loginRequest)
        {
            return await service.Login(loginRequest);
        }

        [HttpGet("greet")]

        public string SendMessage(string message)
        {
            return service.test(message);
        }
    }
}
