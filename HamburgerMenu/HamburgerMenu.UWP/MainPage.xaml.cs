using DryIoc;
using Prism.DryIoc;

namespace HamburgerMenu.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new HamburgerMenu.App());
        }
    }
}
