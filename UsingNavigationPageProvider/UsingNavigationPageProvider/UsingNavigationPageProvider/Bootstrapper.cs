using Prism.Unity;
using UsingNavigationPageProvider.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace UsingNavigationPageProvider
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<ViewA>();
            Container.RegisterTypeForNavigation<ViewB>();
        }
    }
}
