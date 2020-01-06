using Prism.Navigation;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class NonAsyncExamplePageViewModel : BindableBase, IConfirmNavigation
    {
        private readonly INavigationService _navigationService;

        private bool _canNavigateAway;
        public bool CanNavigateAway
        {
            get { return _canNavigateAway; }
            set { SetProperty(ref _canNavigateAway, value); }
        }

        public DelegateCommand NavigateAwayCommand { get; private set; }

        public NonAsyncExamplePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateAwayCommand = new DelegateCommand(NavigateAway);
        }

        private async void NavigateAway()
        {
            await _navigationService.NavigateAsync("ResultPage");
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            return CanNavigateAway;
        }
    }
}
