using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase, IInitialize, IConfirmNavigation, INavigationAware
    {
        private INavigationService _navigationService { get; }
        private IPageDialogService _dialogs { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogs)
        {
            _navigationService = navigationService;
            _dialogs = dialogs;

            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        private bool _isNavigating;
        public bool IsNavigating
        {
            get => _isNavigating;
            set => SetProperty(ref _isNavigating, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public async void Initialize(INavigationParameters parameters)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Message = "Hello from IInitialize. This won't fire again.";
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            IsNavigating = true;
            return true;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            IsNavigating = false;
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        private async void OnNavigateCommandExecuted(string path)
        {
            var result = await _navigationService.NavigateAsync(path);

            if(!result.Success)
            {
                await _dialogs.DisplayAlertAsync("Error", result.Exception.Message, "Ok");

                // OnNavigatedFrom will never be reached
                IsNavigating = false;
            }
        }
    }
}
