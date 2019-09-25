
using System;
using MvvmHelpers;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogModule.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public RegistrationViewModel(IDialogService dialogService)
        {
            Title = "Signup";
            _dialogService = dialogService;

            SubmitCommand = new DelegateCommand(OnSubmitCommandExecuted);
        }

        private string _status = "Pending";
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public DelegateCommand SubmitCommand { get; }

        private void OnSubmitCommandExecuted()
        {
            _dialogService.ShowDialog("TermsDialogView?email=hnabbasi@outlook.com",
                new DialogParameters { { "name", "Hussain Abbasi" } },
                OnTermsAccepted);
        }

        private void OnTermsAccepted(IDialogResult obj)
        {
            if (obj == null || obj.Parameters == null)
                return;

            var isAccepted = obj.Parameters.GetValue<bool>("accepted");
            Status = isAccepted ? "Active" : "Pending";
        }
    }
}

