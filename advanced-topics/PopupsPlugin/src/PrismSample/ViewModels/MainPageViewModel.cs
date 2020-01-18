using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        private IDialogService _dialogService { get; }

        public MainPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            ShowPopupCommand = new DelegateCommand(OnShowPopupCommand);
            ShowDialogCommand = new DelegateCommand(OnShowDialogCommand);
        }

        private string _message = "Hello from MainPage";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand ShowPopupCommand { get; }

        public DelegateCommand ShowDialogCommand { get; }

        private async void OnShowPopupCommand()
        {
            var result = await _navigationService.NavigateAsync("SamplePopup", ("message", Message));
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        private void OnShowDialogCommand()
        {
            _dialogService.ShowDialog("SampleAlert", new DialogParameters("?message=Hello%20from%20MainPage!"), OnDialogClosed);
        }

        private void OnDialogClosed(IDialogResult result)
        {
            if(result.Exception != null)
            {
                System.Diagnostics.Debugger.Break();
                return;
            }

            Console.WriteLine(result.Parameters.GetValue<string>("callbackMessage"));
        }
    }
}
