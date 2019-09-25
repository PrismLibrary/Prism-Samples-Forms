using System;
using MvvmHelpers;
using Prism.AppModel;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogModule.ViewModels
{
    public class TermsDialogViewModel : BaseViewModel, IDialogAware, IAutoInitialize
    {
        public TermsDialogViewModel()
        {
            Title = "Terms and Conditions";
            SubmitCommand = new DelegateCommand(OnSubmitTapped, () => CanSubmit).ObservesProperty(() => CanSubmit);
            CancelCommand = new DelegateCommand(OnCancelTapped);
        }

        public DelegateCommand SubmitCommand { get; }
        public DelegateCommand CancelCommand { get; }

        void OnSubmitTapped()
        {
            RequestClose?.Invoke(new DialogParameters { { "accepted", true } });
        }

        void OnCancelTapped()
        {
            RequestClose?.Invoke(new DialogParameters());
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private bool _canSubmit;
        public bool CanSubmit
        {
            get => _canSubmit;
            set { SetProperty(ref _canSubmit, value); }
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => CanSubmit;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { var x = parameters; }
    }
}
