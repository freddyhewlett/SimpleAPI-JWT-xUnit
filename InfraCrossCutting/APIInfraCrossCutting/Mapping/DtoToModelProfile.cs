using APIDomain.DTOs.User;
using APIDomain.Models;
using AutoMapper;
using System;

namespace APIInfraCrossCutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}
