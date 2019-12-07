using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class TabCPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand TabACommand { get; set; }

        public TabCPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            TabACommand = new DelegateCommand(TabAAction);
        }

        private void TabAAction()
        {
            _navigationService.SelectTabAsync("TabAPage");
        }
    }
}
