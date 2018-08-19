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
        private float batteryLife = SystemInformation.PowerStatus.BatteryLifePercent * 100;
        public float BatteryLife
        {
            get { return batteryLife; }
            set { SetProperty(ref batteryLife, value); }
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
