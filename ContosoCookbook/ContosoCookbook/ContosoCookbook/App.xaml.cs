using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using ContosoCookbook.Views;
using ContosoCookbook.Services;

namespace ContosoCookbook
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IRecipeService, RecipeService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<RecipePage>();
        }
    }
}
