using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Unity;
using UsingPageDialogService.Views;
using Xamarin.Forms;

namespace UsingPageDialogService
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
