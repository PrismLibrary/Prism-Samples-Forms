using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using PrismSample.Models;
using Prism.Services;
using PrismSample.Navigation;

namespace PrismSample
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Your Feedback (Read only)";

            _eventAggregator.GetEvent<IsFunChangedEvent>().Subscribe (IsFunChanged);
            EntryCommand = new DelegateCommand(OnEntryCommandTapped);
            GoBackCommand = new DelegateCommand(OnGoBackCommandTapped);
        }

        public void IsFunChanged (bool isFun)
        {
            IsFun = isFun;
        }

        #region Properties

        private bool _isFun;
        public bool IsFun
        {
            get => _isFun;
            set => SetProperty(ref _isFun, value);
        }

        #endregion

        #region Commands

        public ICommand EntryCommand { get; }

        private void OnEntryCommandTapped()
        {
            _navigationService.NavigateAsync(Navigate.DataEntry, (NavigationParameterKeys.CurrentIsFunValue, IsFun));
        }

        public ICommand GoBackCommand { get; }

        private void OnGoBackCommandTapped()
        {
            _navigationService.GoBackAsync();
        }
        #endregion

        #region Overrides

        public override void Destroy()
        {
            _eventAggregator.GetEvent<IsFunChangedEvent>().Unsubscribe(IsFunChanged);
        }

        #endregion
    }
}
