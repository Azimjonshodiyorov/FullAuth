using Auth.Domain.Entities.Auth.Permissions;
using Auth.Domain.Entities.Auth.RolePermissions;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.Auth.Users;
using Auth.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.Roles
{
    [Table("role" , Schema ="auth_full")]
    public class Role : AuditableBaseEntity<long>
    {
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
