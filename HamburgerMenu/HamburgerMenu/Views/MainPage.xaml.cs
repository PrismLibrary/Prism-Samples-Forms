using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HamburgerMenu.Views
{
    public partial class MainPage : MasterDetailPage, Prism.Navigation.IMasterDetailPageOptions
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get
            {
                return Device.Idiom != TargetIdiom.Phone;
            }
        }
    }
}
