using Auth.Domain.Dtos.UserRoleDto;
using Auth.Domain.Entities.Auth.UserRoles;

namespace Auth.Application.Interfaces
{
    public interface IUserRoleService
    {
        ValueTask<UserRole> AddUserRoleAsync(PostUserRoleDto userRole);
        ValueTask<UserRole> GetUserRoleByIdAsync(long userRoleId);
        IQueryable<UserRole> GetAllUserRoles();
        ValueTask<UserRole> UpdateUserRoleAsync(UpdateUserRoleDto userRole);
        ValueTask<UserRole> DeleteUserRoleAsync(long userRoleId);
    }
}
