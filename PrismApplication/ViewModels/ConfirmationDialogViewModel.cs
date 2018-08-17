using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.ViewModels
{
    public class ConfirmationDialogViewModel : BaseViewModel, IInteractionRequestAware
    {
        #region IInteractionRequestAware

        private Confirmation _confirmation;
        public Action FinishInteraction { get; set; }

        public INotification Notification
        {
            get { return _confirmation; }
            set
            {
                if (value is Confirmation)
                {
                    _confirmation = value as Confirmation;
                    LabelSentense = _confirmation.Content as string;
                }
            }

        }

        #endregion

        #region Property

        private string _labelSentense;
        public string LabelSentense
        {
            get { return _labelSentense; }
            set { SetProperty(ref _labelSentense, value); }
        }

        #endregion

        #region Command

        public DelegateCommand OkCommand =>
            new DelegateCommand(DoOk, CanOk);

        private void DoOk()
        {
            _confirmation.Confirmed = true;
            FinishInteraction();
        }

        private bool CanOk()
        {
            return true;
        }

        #endregion

    }
}
