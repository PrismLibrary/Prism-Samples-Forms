using Microsoft.Practices.Unity;
using Prism.Unity;
using UsingDependencyService.Views;
using Xamarin.Forms;

namespace UsingDependencyService
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            
        }
    }
}
