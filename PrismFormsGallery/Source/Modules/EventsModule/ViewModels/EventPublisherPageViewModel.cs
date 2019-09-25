using System;
using EventsModule.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace EventsModule.ViewModels
{
    public class EventPublisherPageViewModel : MvvmHelpers.BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public EventPublisherPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            Title = "Event Publisher";
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            PublishCommand = new DelegateCommand(OnPublishCommandExecuted);
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand PublishCommand { get; }

        private void OnPublishCommandExecuted()
        {
            _eventAggregator.GetEvent<GreetEvent>().Publish(Message);
            _navigationService.GoBackAsync();
        }
    }
}
