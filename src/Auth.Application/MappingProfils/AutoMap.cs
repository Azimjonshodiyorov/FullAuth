using Auth.Domain.Dtos;
using Auth.Domain.Entities.Auth.Users;
using AutoMapper;

namespace Auth.Application.MappingProfils
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<User , UserDto>();

        }
    }
}
