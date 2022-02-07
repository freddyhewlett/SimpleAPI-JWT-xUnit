using APIDomain.Entities.User;
using APIDomain.Models;
using AutoMapper;
using System;

namespace APIInfraCrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
