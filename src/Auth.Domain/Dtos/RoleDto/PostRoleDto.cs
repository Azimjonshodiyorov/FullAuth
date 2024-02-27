
using Auth.Domain.Entities.BaseEntities;

namespace Auth.Domain.Dtos.RoleDto
{
    public class PostRoleDto
    {
        public string  Name { get; set; }

        public string[]  Permissions { get; set; }
    }
}
