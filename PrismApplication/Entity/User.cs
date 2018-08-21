using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("id", Order = 0)]
        public string Id { get; set; }

        [Key]
        [Column("password", Order = 1)]
        public string Password { get; set; }
    }
}
