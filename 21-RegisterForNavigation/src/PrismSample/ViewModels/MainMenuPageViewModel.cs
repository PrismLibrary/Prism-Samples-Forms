using Prism.Commands;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class MainMenuPageViewModel
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<string> NavigateCommand { get; }
        
        public MainMenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        public async void OnNavigateCommandExecuted(string uri) => 
            await _navigationService.NavigateAsync(uri);
    }
}
