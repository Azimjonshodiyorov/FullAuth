
namespace Auth.Domain.Dtos.UserRoleDto
{
    public class UpdateUserRoleDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}
