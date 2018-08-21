using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismApplication.Common;
using PrismApplication.Repository;
using PrismApplication.Entity;
using Prism.Interactivity.InteractionRequest;

namespace PrismApplication.ViewModels
{
    public class AddUserDialogViewModel : BaseViewModel, IInteractionRequestAware
    {
        public Action FinishInteraction { get; set; }

        private INotification notification;
        public INotification Notification
        {
            get { return notification; }
            set { SetProperty(ref notification, value); }
        }

        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set { SetProperty(ref userPassword, value); }
        }


        public DelegateCommand AddUserCommand => new DelegateCommand(DoAddUser, () => true);

        private void DoAddUser()
        {
            User insertItem = new User { Id = this.UserId, Password = SafePassword.GetStretchedPassword(UserId, UserPassword) };
            RepositoryFactory.instance.UserRepository.Insert(insertItem);
            FinishInteraction();
        }
    }
}
