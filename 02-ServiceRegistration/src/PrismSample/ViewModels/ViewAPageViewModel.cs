using PrismSample.Services;
using Prism.Navigation;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class ViewAPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private int _numberValue;
        public int NumberValue
        {
            get => _numberValue;
            set => SetProperty(ref _numberValue, value);
        }

        public DelegateCommand GoBackCommand { get; private set; }

        public ViewAPageViewModel(INavigationService navigationService, 
            IExampleAlphaService exampleAlphaService)
        {
            _navigationService = navigationService;

            NumberValue = exampleAlphaService.NumberValue;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private async void GoBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
