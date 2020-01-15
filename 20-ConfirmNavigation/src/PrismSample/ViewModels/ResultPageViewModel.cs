using Prism.Navigation;
using Prism.Commands;

namespace PrismSample.ViewModels
{
    public class ResultPageViewModel
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; private set; }

        public ResultPageViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private async void GoBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
