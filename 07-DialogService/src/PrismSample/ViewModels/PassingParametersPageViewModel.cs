using System;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class PassingParametersPageViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        public PassingParametersPageViewModel(IDialogService dialogService)
        {
            Title = "Passing Parameters";
            _dialogService = dialogService;
            TermsCommand = new DelegateCommand(OnTermsCommandTapped);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public DelegateCommand TermsCommand { get; }

        private void OnTermsCommandTapped()
        {
            _dialogService.ShowDialog("TermsDialog", new DialogParameters {
                { "name", Name },
                { "email", "abc@email.com" }
            }, OnDialogClosed);
        }

        private void OnDialogClosed(IDialogResult result)
        {
            // Check for exception
            if (result.Exception != null)
            {
                var e = result.Exception;
                Console.WriteLine($"Dialog failed. {(e.InnerException ?? e).Message}");
                return;
            }

            // Fetch parameters returned by the dialog view
            if (result.Parameters.ContainsKey("accepted"))
                Status = result.Parameters.GetValue<bool>("accepted")
                    ? "Accepted"
                    : "Declined";
        }
    }
}
