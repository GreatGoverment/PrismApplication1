using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using PrismApplication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.ViewModels
{
    public class MessageDialogViewModel : BaseViewModel, IInteractionRequestAware
    {

        #region IInteractionRequestAware

        private MessageNotification messageNotification;
        public Action FinishInteraction { get; set; }

        public INotification Notification
        {
            get { return messageNotification; }
            set
            {
                messageNotification = value as MessageNotification;
                Kind = messageNotification.IconKind;
                Message = messageNotification.Message;
                ButtonContent = messageNotification.ButtonContent;
                IconColor = "red";
            }

        }

        #endregion


        #region Property

        private string kind;
        public string Kind
        {
            get { return kind; }
            set { SetProperty(ref kind, value); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }
            set { SetProperty(ref buttonContent, value); }
        }

        private string iconColor;
        public string IconColor
        {
            get { return iconColor; }
            set { SetProperty(ref iconColor, value); }
        }

        #endregion

        #region Command

        public DelegateCommand OKCommand
            => new DelegateCommand(DoOKCommand, () => true);
            //=> new DelegateCommand(FinishInteraction, () => true);

        private void DoOKCommand()
        {
            FinishInteraction();
        }
        

        #endregion

    }
}
