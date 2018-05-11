using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using Prism.Events;
using UsingEventAggregator.Models;
using UsingEventAggregator.Views;
using System;
using System.Diagnostics;

namespace UsingEventAggregator.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private IEventAggregator _eventAggregator;

        public MainPageViewModel (INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<FormSubmittedEvent>()?.Subscribe(OnFormSubmitted);

            Title = "Prism.Forms EventAggregator";
        }

        private void OnFormSubmitted()
        {
            Debug.WriteLine("Form submitted. Do something...");
        }

        #region Commands

        private ICommand _localCommand;
        public ICommand LocalCommand => _localCommand ?? (_localCommand = new DelegateCommand (OnLocalCommandTapped));

        private void OnLocalCommandTapped ()
        {
            _navigationService.NavigateAsync (nameof (HomePage));
        }

        private ICommand _nativeCommand;
        public ICommand NativeCommand => _nativeCommand ?? (_nativeCommand = new DelegateCommand (OnNativeCommandTapped));

        private void OnNativeCommandTapped ()
        {
            _eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));
        }

        #endregion
    }
}

