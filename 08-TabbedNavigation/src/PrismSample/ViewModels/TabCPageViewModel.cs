using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;

namespace PrismSample.ViewModels
{
    public class TabCPageViewModel : TabPageViewModelBase
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateTabACommand { get; set; }

        public TabCPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            NavigateTabACommand = new DelegateCommand(NavigateTabA);
            Title = "C";
        }

        private async void NavigateTabA()
        {
            await _navigationService.SelectTabAsync("TabAPage");
        }
    }
}
