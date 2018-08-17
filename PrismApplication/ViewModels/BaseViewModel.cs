using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using Microsoft.Practices.Unity;
using PrismApplication.Services;

namespace PrismApplication.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {

        [Dependency]
        public RegionService RegionService { get; set; }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
