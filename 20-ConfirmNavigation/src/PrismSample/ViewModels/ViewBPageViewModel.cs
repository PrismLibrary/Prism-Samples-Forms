using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Commands;
using Prism.Services;

namespace PrismSample.ViewModels
{
    public class ViewBPageViewModel : IConfirmNavigationAsync
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public DelegateCommand NavigateAwayCommand { get; private set; }

        public ViewBPageViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            NavigateAwayCommand = new DelegateCommand(NavigateAway);
        }

        private async void NavigateAway()
        {
            await _navigationService.NavigateAsync("ViewCPage");
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync(string.Empty, "Are you sure you want to navigate away?", "Yes", "No");
        }
    }
}
