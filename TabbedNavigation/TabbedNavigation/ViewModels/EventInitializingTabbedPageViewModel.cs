using System;
using Prism.Events;
using TabbedNavigation.Events;

namespace TabbedNavigation.ViewModels
{
    public class EventInitializingTabbedPageViewModel : BaseViewModel
    {
        IEventAggregator _ea { get; }
        public EventInitializingTabbedPageViewModel(IEventAggregator eventAggregator)
        {
            _ea = eventAggregator;
            Title = "Event Initialized";
        }

        public override void OnNavigatingTo(Prism.Navigation.NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
            _ea.GetEvent<InitializeTabbedChildrenEvent>().Publish(parameters);
        }
    }
}
