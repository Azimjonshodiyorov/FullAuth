using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.Users;
using Auth.Domain.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Domain.Entities.Auth.UserRoles
{
    [Table("user_role" , Schema ="auth_full")]
    public class UserRole : AuditableBaseEntity<long>
    {
        [Column("user_id")]
        public long UserId { get; set; }
        public virtual User  User { get; set; }
        [Column("role_id")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
