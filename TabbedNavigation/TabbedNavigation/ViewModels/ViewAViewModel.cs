using System;
using Prism.Events;

namespace TabbedNavigation.ViewModels
{
    public class ViewAViewModel : ChildViewModelBase
    {
        public ViewAViewModel(IEventAggregator ea ) : base(ea)
        {
            Title = "View A";
        }
    }
}
