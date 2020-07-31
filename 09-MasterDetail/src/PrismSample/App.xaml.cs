using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using PrismSample.ViewModels;
using PrismSample.Views;
using System;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PrismSample
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                string viewModelTypeName = viewType.FullName.Replace("Page", "ViewModel");
                Type viewModelType = Type.GetType(viewModelTypeName);
                return viewModelType;
            });

            await NavigationService.NavigateAsync("Main/Nav/Welcome");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>("Nav");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>("Main");
            containerRegistry.RegisterForNavigation<WelcomePage>("Welcome");

            containerRegistry.RegisterForNavigation<SampleOnePage>("SampleOne");
            containerRegistry.RegisterForNavigation<SampleTwoPage>("SampleTwo");
            containerRegistry.RegisterForNavigation<SampleThreePage>("SampleThree");
        }
    }
}
