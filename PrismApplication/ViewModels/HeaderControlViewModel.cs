using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.ViewModels
{
    public class HeaderControlViewModel : BaseViewModel , INavigationAware
    {
        public static int displayTimes;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { base.SetProperty(ref _title, value); }
        }

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            this.Title = parameters["Title"] as string;
            return true;
        }
    }
}
