using Prism.Navigation;

using Xamarin.Forms;

namespace UsingNavigationPageProvider.Views
{
    [NavigationPageProvider(typeof(ViewANavigationPageProvider))]
    public partial class ViewA : ContentPage
    {
        public ViewA()
        {
            InitializeComponent();
        }
    }
}
