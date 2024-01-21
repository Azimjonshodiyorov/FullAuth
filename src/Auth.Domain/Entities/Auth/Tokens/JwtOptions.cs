using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.Tokens
{
    [Table("jwt_option", Schema ="auth_full")]
    public class JwtOptions
    {
        [Column("issuer")] 
        public string Issuer { get; set; }
        [Column("audience")] 
        public string Audience { get; set; }
        [Column("secret_key")] 
        public string SecretKey { get; set; }
        [Column("access_token_expires")]
        public double AccessTokenExpires { get; set; }
    }
}
