using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using PrismApplication.Entity;
using PrismApplication.Repository;
using PrismApplication.Views;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;

namespace PrismApplication.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        public InteractionRequest<Confirmation> ConfirmDialogRequest { get; }
            = new InteractionRequest<Confirmation>();


        public DelegateCommand ConfirmationCommand =>
            new DelegateCommand(DoConfirmation, CanConfirmation);

        private void DoConfirmation()
        {
            ConfirmDialogRequest.Raise(
                new Confirmation { Title = "DialogTest1", Content = "This is ConfirmationDialog.OK?" },
                n =>
                {
                    if (n.Confirmed)
                    {
                        System.Windows.MessageBox.Show("Yes Pressed");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Pressed");
                    }
                });
        }

        private bool CanConfirmation()
        {
            return true;
        }



        public DelegateCommand AccessDBCommand =>
            new DelegateCommand(DoAccessDB, () => true);

        private void DoAccessDB()
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=D:\\DataBase\\PrismApplicationDB1.sqlite3"))
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                con.Open();

                cmd.CommandText = "SELECT * FROM Setting";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Windows.MessageBox.Show("key=" + reader[0] + "\nvalue=" + reader[1]);
                    }
                }
            }
        }


        public DelegateCommand FrameworkDBCommand =>
            new DelegateCommand(DoFrameworkDB, () => true);

        private void DoFrameworkDB()
        {
            using (var context = new MyDbContext())
            {
                RepositoryFactory rf = new RepositoryFactory();
                List<Setting> settings = rf.SettingRepository.FindAll();
                System.Windows.MessageBox.Show("key=" + settings[0].Key + "\nvalue=" + settings[0].Value);
            }
        }


        public DelegateCommand PingCommand =>
            new DelegateCommand(DoPing, () => true);

        private void DoPing()
        {
            Ping p = new Ping();
            PingReply reply = p.Send("www.yahoo.com");

            if (reply.Status == IPStatus.Success)
            {
                System.Windows.MessageBox.Show("success " + reply.Address);
            }
            else
            {
                System.Windows.MessageBox.Show("failure");
            }
        }


        public DelegateCommand NextPageCommand =>
            new DelegateCommand(DoNextPage, () => true);

        private void DoNextPage()
        {
            RegionService.HeaderNavigate(nameof(HeaderControl), "KPT");
            RegionService.MainNavigate(nameof(SecondPage), nameof(KeepProblemTry));
        }
        
        /*
        public DelegateCommand BackCommand =>
            new DelegateCommand(DoBack, () => true);

        private void DoBack()
        {
            RegionService.HeaderNavigate(nameof(HeaderControl), "FirstPage");
            RegionService.MainNavigate(nameof(MainPage));
        }
        */

    }
}
