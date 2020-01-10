using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using PrismSample.Models;

namespace PrismSample
{
    public class DataEntryPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public DataEntryPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "So what do you think?";
            SubmitCommand = new DelegateCommand(OnSubmitTapped);
        }

        private bool _isFun;
        public bool IsFun
        {
            get => _isFun;
            set => SetProperty(ref _isFun, value, () => _eventAggregator.GetEvent<IsFunChangedEvent>().Publish(value));
        }

        public ICommand SubmitCommand { get; }

        private void OnSubmitTapped()
        {
            _navigationService.GoBackAsync ();
        }
    }
}
