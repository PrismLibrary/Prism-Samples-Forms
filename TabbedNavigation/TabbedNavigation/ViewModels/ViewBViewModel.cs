using System;
using Prism.Events;

namespace TabbedNavigation.ViewModels
{
    public class ViewBViewModel : ChildViewModelBase
    {
        public ViewBViewModel(IEventAggregator ea ) : base(ea)
        {
            Title = "View B";
        }
    }
}
