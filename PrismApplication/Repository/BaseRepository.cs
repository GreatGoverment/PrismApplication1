using PrismApplication.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly MyDbContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(MyDbContext context, DbSet<T> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        public virtual List<T> FindAll()
        {
            return dbSet.ToList();
        }
    }
}
