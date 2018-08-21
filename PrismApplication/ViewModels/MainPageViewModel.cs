using Prism.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Regions;
using PrismApplication.Views;
using PrismApplication.Services;
using Prism.Commands;
using System.Windows;
using System.Collections.Generic;
using PrismApplication.Common;
using PrismApplication.Entity;
using PrismApplication.Repository;
using System.ComponentModel;

namespace PrismApplication.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        #region Property

        private string id;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


        private string siteTitle;
        public string SiteTitle
        {
            get { return siteTitle; }
            set { SetProperty(ref siteTitle, value); }
        }

        private string siteURL;
        public string SiteURL
        {
            get { return siteURL; }
            set { SetProperty(ref siteURL, value); }
        }

        private BindingList<InternetLink> linkItems;
        public BindingList<InternetLink> LinkItems
        {
            get { return linkItems; }
            set { SetProperty(ref linkItems, value); }
        }

        private bool linkDialogIsOpen;
        public bool LinkDialogIsOpen
        {
            get { return linkDialogIsOpen; }
            set { SetProperty(ref linkDialogIsOpen, value); }
        }

        #endregion

        public MainPageViewModel()
        {
            LinkItems = new BindingList<InternetLink>(RepositoryFactory.instance.InternetLinkRepository.FindAll());
        }


        public DelegateCommand SubmitCommand =>
            new DelegateCommand(DoSubmit, CanSubmit)
            .ObservesProperty(() => Id)
            .ObservesProperty(() => Password);

        private void DoSubmit()
        {

            User loginUser 
                = RepositoryFactory.instance.UserRepository.FindOne(Id, SafePassword.GetStretchedPassword(Id, Password));
            if (loginUser is null)
            {
                System.Console.WriteLine("Login Failed");
            }
            else
            {
                RegionService.MainNavigate(nameof(MainPage), nameof(SecondPage));
            }
        }

        private bool CanSubmit() =>
            !(string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Password));



        public DelegateCommand AddLinkCommand =>
            new DelegateCommand(DoAddLink, () => true);

        private void DoAddLink()
        {
            InternetLink insertItem = new InternetLink { SiteTitle = this.SiteTitle, SiteURL = this.SiteURL };
            LinkItems.Add(insertItem);
            RepositoryFactory.instance.InternetLinkRepository.Insert(insertItem);
            LinkDialogIsOpen = false;
        }

    }
}
