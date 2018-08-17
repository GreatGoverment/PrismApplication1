using PrismApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Repository
{
    public class RepositoryFactory
    {
        MyDbContext context = new MyDbContext();



        public RepositoryFactory()
        {
            SettingRepository = new SettingRepository(context);
        }

        public SettingRepository SettingRepository { get; }
    }

}
