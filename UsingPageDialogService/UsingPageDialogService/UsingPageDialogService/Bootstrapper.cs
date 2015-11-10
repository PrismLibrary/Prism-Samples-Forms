using Prism.Unity;
using UsingPageDialogService.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace UsingPageDialogService
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
