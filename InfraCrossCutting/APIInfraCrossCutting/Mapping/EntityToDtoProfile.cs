using APIDomain.DTOs.User;
using APIDomain.Entities.User;
using AutoMapper;
using System;

namespace APIInfraCrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserDtoCreateResult, User>().ReverseMap();
            CreateMap<UserDtoUpdateResult, User>().ReverseMap();
        }
    }
}
