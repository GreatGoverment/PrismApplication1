using Microsoft.Practices.Prism.Commands;
using Prism.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Regions;
using PrismApplication.Views;
using PrismApplication.Services;
using System.Windows;

namespace PrismApplication.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }



        public DelegateCommand SubmitCommand =>
            new DelegateCommand(DoSubmit, CanSubmit);

        private void DoSubmit()
        {
            RegionService.HeaderNavigate(nameof(HeaderControl), "SecondPage");
            RegionService.MainNavigate(nameof(SecondPage));
        }

        private bool CanSubmit()
        {
            return true;
        }

    }
}
