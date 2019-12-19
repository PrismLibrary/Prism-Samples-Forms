using System;
using Prism.AppModel;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class LockingDialogViewModel : BaseViewModel, IDialogAware
    {
        public LockingDialogViewModel()
        {
            CloseCommand = new DelegateCommand(OnCloseTapped);
        }

        private bool _canClose;
        public bool CanClose
        {
            get { return _canClose; }
            set { SetProperty(ref _canClose, value); }
        }

        private bool _closeOnTap;
        public bool CloseOnTap
        {
            get { return _closeOnTap; }
            set { SetProperty(ref _closeOnTap, value); }
        }

        private void OnCloseTapped()
        {
            RequestClose.Invoke(new DialogParameters());
        }

        public DelegateCommand CloseCommand { get; set; }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => CanClose;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // For CloseOnTap sample #3.
            if (parameters.ContainsKey("CloseOnTap"))
                CloseOnTap = CanClose = parameters.GetValue<bool>("CloseOnTap");
        }
    }
}
