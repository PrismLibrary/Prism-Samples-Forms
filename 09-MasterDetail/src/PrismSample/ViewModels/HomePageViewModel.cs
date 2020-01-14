using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        public DelegateCommand TabbedPageCommand { get; }
        public DelegateCommand MainPageCommand { get; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainPageCommand = new DelegateCommand(MainPageAction);
            TabbedPageCommand = new DelegateCommand(TabbedPageAction);
        }

        private async void TabbedPageAction()
        {
            await _navigationService.NavigateAsync("/HomePage/NavigationPage/TabbedPage" +
                                                   $"?{KnownNavigationParameters.CreateTab}=TabAPage" +
                                                   $"&{KnownNavigationParameters.CreateTab}=TabBPage");
        }

        private async void MainPageAction()
        {
            await _navigationService.NavigateAsync("/HomePage/NavigationPage/MainPage");
        }

    }
}
