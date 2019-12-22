using Prism.Navigation;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToViewACommand { get; private set; }
        public DelegateCommand GoToViewBCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToViewACommand = new DelegateCommand(GoToViewA);
            GoToViewBCommand = new DelegateCommand(GoToViewB);
        }

        private async void GoToViewA()
        {
            await _navigationService.NavigateAsync("ViewAPage");
        }

        private async void GoToViewB()
        {
            await _navigationService.NavigateAsync("ViewBPage");
        }
    }
}
