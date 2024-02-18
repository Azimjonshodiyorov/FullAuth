
using Auth.Domain.Dtos.PermissionsDto;
using Auth.Domain.Entities.Auth.Permissions;

namespace Auth.Application.Interfaces
{
    public interface IPermissionService
    {
        ValueTask<Permission> AddPermissionAsync(PostPermissionDto permission);
        ValueTask<Permission> GetPermissionByIdAsync(long permissionId);
        IQueryable<Permission> GetAllPermissions();
        ValueTask<Permission> UpdatePermissionAsync(UpdatePermissionDto permission);
        ValueTask<Permission> DeletePermissionAsync(long permissionId);
    }
}
