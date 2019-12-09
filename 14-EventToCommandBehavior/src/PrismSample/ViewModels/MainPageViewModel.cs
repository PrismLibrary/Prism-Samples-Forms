using System.Threading.Tasks;
using PrismSample.Views;
using Prism.Navigation;
using Prism.Commands;
using Xamarin.Forms;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToEventArgsConverterExamplePageCommand { get; private set; }
        public DelegateCommand GoToEventArgsParameterExamplePageCommand { get; private set; }
        public DelegateCommand GoToSimpleExamplePageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToEventArgsConverterExamplePageCommand = new DelegateCommand(async () => await GoToEventArgsConverterExamplePage());
            GoToEventArgsParameterExamplePageCommand = new DelegateCommand(async () => await GoToEventArgsParameterExamplePage());
            GoToSimpleExamplePageCommand = new DelegateCommand(async () => await GoToSimpleExamplePage());
        }

        private async Task GoToEventArgsConverterExamplePage()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(EventArgsConverterExamplePage));
        }

        private async Task GoToEventArgsParameterExamplePage()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(EventArgsParameterExamplePage));
        }

        private async Task GoToSimpleExamplePage()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(SimpleExamplePage));
        }
    }
}
