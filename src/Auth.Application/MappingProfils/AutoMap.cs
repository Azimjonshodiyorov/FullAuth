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
            CreateMap<User , UserDto>();
            CreateMap<UserRole , PostUserRoleDto>();
            CreateMap<UserRole , GetUserRoleDto>();
            CreateMap<UserRole , UpdateUserRoleDto>();
            CreateMap<Permission, UpdatePermissionDto>();
            CreateMap<Permission, DeletePermissionDto>();
            CreateMap<Permission, PostPermissionDto>();
            CreateMap<Permission, GetPermissionDto>();
            CreateMap<Role, DeleteRoleDto>();
            CreateMap<Role, UpdateRoleDto>();
            CreateMap<Role, PostRoleDto>();
            CreateMap<Role, GetRoleDto>();
        }
    }
}
