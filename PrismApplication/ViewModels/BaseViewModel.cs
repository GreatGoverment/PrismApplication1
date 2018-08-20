using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using Microsoft.Practices.Unity;
using PrismApplication.Services;
using Prism.Commands;

namespace PrismApplication.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        public static Stack<string> viewStack = new Stack<string>();
        

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

        
        public DelegateCommand BackCommand =>
            new DelegateCommand(DoBack, CanBack);
            //.ObservesProperty(() => viewStack);

        private void DoBack()
        {
            if (viewStack.Any())
            {
                RegionService.BackNavigate(viewStack.Pop());
            }
        }
        //private bool CanBack() => viewStack.Any();
        private bool CanBack() => true;
    }
}
