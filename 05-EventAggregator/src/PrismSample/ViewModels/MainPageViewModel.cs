using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using Prism.Events;
using PrismSample.Models;
using PrismSample.Navigation;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private IEventAggregator _eventAggregator;

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Prism.Forms EventAggregator";
            LocalCommand = new DelegateCommand(OnLocalCommandTapped);
            NativeCommand = new DelegateCommand(OnNativeCommandTapped);
        }

        #region Commands

        public ICommand LocalCommand { get; }

        private void OnLocalCommandTapped()
        {
            _navigationService.NavigateAsync(Navigate.Home);
        }

        public ICommand NativeCommand { get; }

        private void OnNativeCommandTapped()
        {
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Xamarin.Forms"));
        }

        #endregion
    }
}

