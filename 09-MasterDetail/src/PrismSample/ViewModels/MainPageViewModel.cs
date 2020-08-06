using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private async void NavigateCommandExecuted(string view)
        {
            var result = await _navigationService.NavigateAsync($"NavigationPage/{view}");
            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
