using PrismSample.Services;
using Prism.Navigation;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class ViewBPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private int _numberValue;
        public int NumberValue
        {
            get => _numberValue;
            set => SetProperty(ref _numberValue, value);
        }

        public DelegateCommand GoBackCommand { get; private set; }

        public ViewBPageViewModel(INavigationService navigationService,
            IExampleBetaService exampleBetaService)
        {
            _navigationService = navigationService;

            NumberValue = exampleBetaService.NumberValue;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private async void GoBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
