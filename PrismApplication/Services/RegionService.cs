using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;
using PrismApplication.ViewModels;

namespace PrismApplication.Services
{
    public class RegionService
    {
        [Dependency]
        public IRegionManager RegionManager { private get; set; }


        #region NavigationService

        public void HeaderNavigate(string viewName, string title)
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "Title", title }
            };

            RegionManager.RequestNavigate("Header", viewName, parameters);
        }

        public void BackNavigate(string viewName)
        {
            RegionManager.RequestNavigate("Main", viewName);
        }

        public void MainNavigate(string fromViewName, string toViewName)
        {
            BaseViewModel.viewStack.Push(fromViewName);
            RegionManager.RequestNavigate("Main", toViewName);
        }

        public void MainNavigate(string viewName, NavigationParameters parameters)
        {
            RegionManager.RequestNavigate("Main", viewName, parameters);
        }

        #endregion

    }
}
