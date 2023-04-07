using AutoMapper;
using Domain.Entities;
using Service.DTOs;

namespace Service.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
        }
    }
}
