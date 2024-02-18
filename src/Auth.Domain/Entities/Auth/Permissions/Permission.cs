using Auth.Domain.Entities.Auth.RolePermissions;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Auth.Domain.Entities.Auth.Permissions
{
    [Table("ermission",Schema ="auth_full" )]
    public class Permission  : AuditableBaseEntity<long>
    {
        [Column("name")]
        public string  Name { get; set; }
        [Column("code")]
        public int Code { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
