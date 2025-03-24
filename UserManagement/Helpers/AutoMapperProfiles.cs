using AutoMapper;
using UserManagement.DTOs;
using UserManagement.Models;

namespace UserManagement.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Users, UserDto>()
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.Id));
        }


    }
}
