using System;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public MainPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            TermsCommand = new DelegateCommand(OnTermsCommandTapped);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public DelegateCommand TermsCommand { get; set; }

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
            if(result.Exception != null)
            {
                var e = result.Exception;
                Console.WriteLine($"Dialog failed. {(e.InnerException??e).Message}");
                return;
            }

            // Fetch parameters returned by the dialog view
            if (result.Parameters.ContainsKey("accepted"))
                Status = result.Parameters.GetValue<bool>("accepted")
                    ? "Accepted"
                    : "Rejected";
        }
    }
}
