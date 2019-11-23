using System;
using CommandingModule.Views;
using Prism.Commands;
using Prism.Navigation;

namespace CommandingModule.ViewModels
{
    public class LoginPageViewModel : MvvmHelpers.BaseViewModel
    {
        readonly INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService)
        {
            Title = "Commanding";
            _navigationService = navigationService;

            SubmitCommand = new DelegateCommand(OnSumbitTapped, () => CanSubmit).ObservesProperty(() => CanSubmit);
        }

        private void OnSumbitTapped()
        {
            _navigationService.NavigateAsync("HomePage");
        }

        private string _name;
        public string Name { get => _name; set { SetProperty(ref _name, value); } }

        private bool _canSubmit;
        public bool CanSubmit { get => _canSubmit; set { SetProperty(ref _canSubmit, value); } }

        public DelegateCommand SubmitCommand { get; }
    }
}
