using PrismApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Repository
{
    public class SettingRepository : BaseRepository<Setting>
    {
        public SettingRepository(MyDbContext context) : base(context, context.Settings)
        {

        }

        public override void Insert(Setting t)
        {
            throw new NotImplementedException();
        }
    }
}
