using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace TabbedNavigation.Views
{
    public partial class NavigatingAwareTabbedPage : TabbedPage, INavigatingAware
    {
        public NavigatingAwareTabbedPage()
        {
            InitializeComponent();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            foreach( var child in Children )
            {
                (child as INavigatingAware)?.OnNavigatingTo(parameters);
                (child?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);
            }
        }
    }
}
