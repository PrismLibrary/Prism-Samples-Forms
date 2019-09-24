using EventsModule.Events;
using MvvmHelpers;
using Prism.Events;

namespace EventsModule.ViewModels
{
    public class EventPageViewModel : BaseViewModel
    {
        public EventPageViewModel(IEventAggregator eventAggregator)
        {
            Title = "Event Aggregator";

            eventAggregator?.GetEvent<GreetEvent>()?.Subscribe(OnMessageReceived);
        }

        void OnMessageReceived(string message)
        {
            Message = message;
        }

        private string _message = "No message";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
