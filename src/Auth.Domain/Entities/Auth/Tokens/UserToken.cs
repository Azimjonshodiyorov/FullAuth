using Auth.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.Tokens
{
    public class UserToken : AuditableBaseEntity<long>
    {
        [Column("access_token")]
        public string AccessToken { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
