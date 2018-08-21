using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismApplication.Entity;

namespace PrismApplication.Repository
{
    public class InternetLinkRepository : BaseRepository<InternetLink>
    {
        public InternetLinkRepository(MyDbContext context) : base(context, context.InternetLinks) { }
        
        public override void Insert(InternetLink il)
        {
            context.InternetLinks.Add(il);
            context.SaveChanges();
        }
    }
}
