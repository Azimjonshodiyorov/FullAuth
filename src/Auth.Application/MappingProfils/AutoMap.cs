using Auth.Domain.Dtos.PermissionsDto;
using Auth.Domain.Dtos.RoleDto;
using Auth.Domain.Dtos.UserDto;
using Auth.Domain.Dtos.UserRoleDto;
using Auth.Domain.Entities.Auth.Permissions;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.Auth.Users;
using AutoMapper;

namespace Auth.Application.MappingProfils
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<User , UserDto>().ReverseMap();
            CreateMap<UserRole , PostUserRoleDto>().ReverseMap();
            CreateMap<UserRole , GetUserRoleDto>().ReverseMap();
            CreateMap<UserRole , UpdateUserRoleDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();
            CreateMap<Permission, DeletePermissionDto>().ReverseMap();
            CreateMap<Permission, PostPermissionDto>().ReverseMap();
            CreateMap<Permission, GetPermissionDto>().ReverseMap();
            CreateMap<Role, DeleteRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();
            CreateMap<Role, PostRoleDto>().ReverseMap();
            CreateMap<Role, GetRoleDto>().ReverseMap();
        }
    }
}
