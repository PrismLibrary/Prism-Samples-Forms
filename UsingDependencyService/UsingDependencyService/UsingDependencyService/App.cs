

using Prism.Unity;
using UsingDependencyService.Views;

namespace UsingDependencyService
{
    public class App : PrismApplication 
    {
        protected override void OnInitialized() 
        {
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes() 
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
