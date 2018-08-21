using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using PrismApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrismApplication.ViewModels
{
    public class ShellViewModel : BaseViewModel, INavigationAware
    {
        public InteractionRequest<Notification> AddUserDialogRequest { get; } = new InteractionRequest<Notification>();

        private float batteryLife = SystemInformation.PowerStatus.BatteryLifePercent * 100;
        public float BatteryLife
        {
            get { return batteryLife; }
            set { SetProperty(ref batteryLife, value); }
        }

        public DelegateCommand AddUserCommand => new DelegateCommand(DoAddUser, () => true);
        private void DoAddUser()
        {

            AddUserDialogRequest.Raise(new Notification() { Title = "testtest"});
        }


        public ShellViewModel(IRegionManager rm)
        {
            NavigationParameters np = new NavigationParameters
            {
                {"Title", "FirstPage"}
            };

            rm.RequestNavigate("Header", nameof(HeaderControl), np);
            rm.RequestNavigate("Main", nameof(MainPage));
        }
    }
}
