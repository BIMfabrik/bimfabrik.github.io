using AutoMapper;
using bimfabrik.model.Dtos;
using bimfabrik.model.Entities;

namespace bimfabrik.model.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
