using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=SQLiteDB")
        {

        }

        public DbSet<Setting> Settings { get; set; }
    }
}
