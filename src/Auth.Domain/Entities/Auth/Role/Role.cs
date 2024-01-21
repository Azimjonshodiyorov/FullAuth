using Auth.Domain.Entities.Auth.Permissions;
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

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
