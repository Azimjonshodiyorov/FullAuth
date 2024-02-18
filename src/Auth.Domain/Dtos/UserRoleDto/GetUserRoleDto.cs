
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.Users;

namespace Auth.Domain.Dtos.UserRoleDto
{
    public class GetUserRoleDto
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
