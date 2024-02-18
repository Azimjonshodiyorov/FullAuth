

using Auth.Domain.Dtos.PermissionsDto;

namespace Auth.Domain.Dtos.RoleDto
{
    public class UpdateRoleDto
    {
        public long Id { get; set; }
        public string RoleName { get; set; }

        public UpdatePermissionDto[] Permissions { get; set; }
    }
}
