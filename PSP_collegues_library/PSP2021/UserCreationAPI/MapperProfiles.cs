using AutoMapper;
using Database.Entities;
using UserCreationApi.Dto;

namespace UserCreationApi
{
    public class MapperProfiles
    {
        public class AppProfile : Profile
        {
            public AppProfile()
            {
                CreateMap<UserDto, User>();
                CreateMap<User, UserDto>();
            }
        }
    }
}
