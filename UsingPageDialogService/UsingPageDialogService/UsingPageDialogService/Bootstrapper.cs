using Prism.Unity;
using UsingPageDialogService.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using System;

namespace UsingPageDialogService
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void OnInitialized()
        {
            NavigationService.Navigate("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
