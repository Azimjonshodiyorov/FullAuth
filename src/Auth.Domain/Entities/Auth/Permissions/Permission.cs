using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.Permissions
{
    [Table("ermission",Schema ="auth_full" )]
    public class Permission 
    {
        [Column("name")]
        public MultiLanguageField  Name { get; set; }
        [Column("code")]
        public int Code { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
