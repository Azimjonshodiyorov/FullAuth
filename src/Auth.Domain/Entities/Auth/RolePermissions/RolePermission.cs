using Auth.Domain.Entities.Auth.Permissions;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.RolePermissions
{
    [Table("role_permission" , Schema ="auth_full")]
    public class RolePermission : AuditableBaseEntity<long>
    {
        [Column("role_id")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        [Column("permission_id")]
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
