using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UsingDependencyService.Views;
using Xamarin.Forms;

namespace UsingDependencyService
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
