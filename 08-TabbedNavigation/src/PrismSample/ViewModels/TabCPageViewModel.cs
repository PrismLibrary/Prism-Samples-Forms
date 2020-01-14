using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class TabCPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        public DelegateCommand TabACommand { get; }

        public TabCPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            TabACommand = new DelegateCommand(TabAAction);
        }

        private async void TabAAction()
        {
            await _navigationService.SelectTabAsync("TabAPage");
        }
    }
}
