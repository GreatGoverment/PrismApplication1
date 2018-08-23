using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prism.Commands;

namespace PrismApplication.ViewModels
{
    public class ParallelTestPageViewModel : BaseViewModel
    {
        public ParallelTestPageViewModel()
        {
            InitializeProgressStatus();
        }

        #region Property

        private string progressStatus;
        public string ProgressStatus
        {
            get { return progressStatus; }
            set { SetProperty(ref progressStatus, value); }
        }

        #endregion

        #region Command

        private bool canPressButton;

        public DelegateCommand NoParallelCommand =>
            new DelegateCommand(DoNoParallel, () => true);
        private void DoNoParallel()
        {
            WaitAMinute();
        }

        public DelegateCommand ParallelCommand =>
            new DelegateCommand(DoParallel, () => true);
        private void DoParallel()
        {
            Task task = Task.Factory.StartNew(WaitAMinute);
        }

        private void WaitAMinute()
        {
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                ProgressStatus = i + 1 + "%";
            }
        }

        private void InitializeProgressStatus()
        {
            ProgressStatus = "0%";
        }

        #endregion
    }
}
