using Auth.Domain.Entities.Auth.Users;
using Auth.Domain.Entities.BaseEntities;
using Auth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.Products
{
    [Table("product" ,Schema ="auth_full") ]
    public class Product : AuditableBaseEntity<long>
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Discription { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("product_status")]
        public ProductStatus ProductStatus { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
