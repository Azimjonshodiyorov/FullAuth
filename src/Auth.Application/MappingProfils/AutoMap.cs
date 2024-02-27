using Auth.Domain.Dtos.PermissionsDto;
using Auth.Domain.Dtos.ProductDto;
using Auth.Domain.Dtos.RoleDto;
using Auth.Domain.Dtos.RolePermissionsDto;
using Auth.Domain.Dtos.UserDto;
using Auth.Domain.Dtos.UserRoleDto;
using Auth.Domain.Entities.Auth.Permissions;
using Auth.Domain.Entities.Auth.RolePermissions;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.Auth.Users;
using Auth.Domain.Entities.Products;
using AutoMapper;

namespace Auth.Application.MappingProfils
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<User , GetAllUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, PostUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, DeleteUserDto>().ReverseMap();
            CreateMap<User, UserCredentials>().ReverseMap();

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


            CreateMap<Product , DeleteProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, PostProductDto>().ReverseMap();



            CreateMap<RolePermission, PostRolePermission>().ReverseMap();
            CreateMap<RolePermission, DeleteRolePermission>().ReverseMap();
            CreateMap<RolePermission, UpdateRolePermission>().ReverseMap();
            CreateMap<RolePermission, DeleteRolePermission>().ReverseMap();

            


        }
    }
}
