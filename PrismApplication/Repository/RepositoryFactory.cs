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

        public static RepositoryFactory instance = new RepositoryFactory();

        private RepositoryFactory()
        {
            SettingRepository = new SettingRepository(context);
            InternetLinkRepository = new InternetLinkRepository(context);
            UserRepository = new UserRepository(context);
        }

        public SettingRepository SettingRepository { get; }
        public InternetLinkRepository InternetLinkRepository { get; }
        public UserRepository UserRepository { get; }
    }

}
