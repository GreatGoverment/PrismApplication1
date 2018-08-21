using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Entity
{
    [Table("InternetLink")]
    public class InternetLink
    {
        [Key]
        [Column("site_title")]
        public virtual string SiteTitle { get; set; }

        [Url]
        [Column("site_url")]
        public virtual string SiteURL { get; set; }

    }
}
