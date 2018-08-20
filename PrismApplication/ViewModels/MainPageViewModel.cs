using Microsoft.Practices.Prism.Commands;
using Prism.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Regions;
using PrismApplication.Views;
using PrismApplication.Services;
using System.Windows;
using System.Collections.Generic;
using PrismApplication.Entity;

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

        private List<HyperLinkItem> linkItems;
        public List<HyperLinkItem> LinkItems
        {
            get { return linkItems; }
            set { SetProperty(ref linkItems, value); }
        }


        public MainPageViewModel()
        {
            LinkItems = new List<HyperLinkItem>
            {
                new HyperLinkItem{Title = "Yahoo! Japan", LinkURL="https://www.yahoo.co.jp/"},
                new HyperLinkItem{Title = "Google", LinkURL="https://www.google.co.jp/"},
                new HyperLinkItem{Title = "Material Design In XAML", LinkURL="https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit"}
            };
        }


        public DelegateCommand SubmitCommand =>
            new DelegateCommand(DoSubmit, CanSubmit);

        private void DoSubmit()
        {
            RegionService.HeaderNavigate(nameof(HeaderControl), "SecondPage");
            RegionService.MainNavigate(nameof(MainPage), nameof(SecondPage));
        }

        private bool CanSubmit()
        {
            return true;
        }

    }
}
