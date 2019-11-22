using System;
using Prism.Ioc;
using PrismSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSample
{
    public partial class App
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var mainPage = new TabbedPage();
            mainPage.Children.Add(new NavigationPage(new MainPage()) { Title = "View A" });
            mainPage.Children.Add(new NavigationPage(new MainPage()) { Title = "View B" });
            mainPage.Children.Add(new NavigationPage(new MainPage()) { Title = "View C" });
            MainPage = mainPage;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
