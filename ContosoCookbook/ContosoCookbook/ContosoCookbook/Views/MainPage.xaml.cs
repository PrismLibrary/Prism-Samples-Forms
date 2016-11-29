using ContosoCookbook.Business;
using ContosoCookbook.ViewModels;
using Xamarin.Forms;

namespace ContosoCookbook.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MainPageViewModel)this.BindingContext).RecipeSelectedCommand.Execute((Recipe)args.Item);            
        }
    }
}