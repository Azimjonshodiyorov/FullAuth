
using Auth.Domain.Dtos.PermissionsDto;

namespace Auth.Domain.Dtos.RoleDto
{
    public class GetRoleDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public GetPermissionDto[] Permission { get; set; }

    }
}
