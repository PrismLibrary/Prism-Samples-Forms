using Prism.Navigation;
using Xamarin.Forms;

namespace HamburgerMenu.Views
{
    public partial class MainPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}
