using Auth.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Auth.Tokens
{
    public class UserRefreshToken : AuditableBaseEntity<long>
    {
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("tefresh_token")]
        public string   RefreshToken { get; set; }
        [Column("expiration_in_minutes")]
        public DateTime ExpirationInMinutes { get; set; }
    }
}
