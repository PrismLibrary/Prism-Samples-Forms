using System;
using Prism.Events;

namespace TabbedNavigation.ViewModels
{
    public class ViewCViewModel : ChildViewModelBase
    {
        public ViewCViewModel(IEventAggregator ea ) : base(ea)
        {
            Title = "View C";
        }
    }
}
