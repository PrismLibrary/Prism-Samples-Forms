using Unity;
using Prism;
using Prism.Ioc;
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRecipeService, RecipeService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<RecipePage>();
        }
    }
}
