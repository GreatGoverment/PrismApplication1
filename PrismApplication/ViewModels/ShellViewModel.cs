using Prism.Regions;
using PrismApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.ViewModels
{
    public class ShellViewModel : BaseViewModel, INavigationAware
    {
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
