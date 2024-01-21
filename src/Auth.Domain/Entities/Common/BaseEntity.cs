using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.BaseEntities
{
    public abstract class BaseEntity<T>
    {
        [Key , Column("id") ]
        public T Id { get; set; }
    }
}
