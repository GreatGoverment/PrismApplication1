using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using PrismApplication.Views;

namespace PrismApplication.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        public InteractionRequest<Confirmation> ConfirmDialogRequest { get; }
            = new InteractionRequest<Confirmation>();


        public DelegateCommand ConfirmationCommand =>
            new DelegateCommand(DoConfirmation, CanConfirmation);

        private void DoConfirmation()
        {
            ConfirmDialogRequest.Raise(
                new Confirmation { Title = "DialogTest1", Content = "This is ConfirmationDialog.OK?" },
                n =>
                {
                    if (n.Confirmed)
                    {
                        System.Windows.MessageBox.Show("Yes Pressed");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Pressed");
                    }
                });
        }

        private bool CanConfirmation()
        {
            return true;
        }



        public DelegateCommand BackCommand =>
            new DelegateCommand(DoBack, () => true);

        private void DoBack()
        {
            RegionService.HeaderNavigate(nameof(HeaderControl), "FirstPage");
            RegionService.MainNavigate(nameof(MainPage));
        }

    }
}
