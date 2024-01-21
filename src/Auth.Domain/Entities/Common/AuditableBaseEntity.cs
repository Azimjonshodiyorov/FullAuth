using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.BaseEntities
{
    public abstract class AuditableBaseEntity<T> : BaseEntity<T> 
    {
        [Column("create_at")]
        public DateTime  CreateAt { get; set; } = DateTime.Now;
        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
