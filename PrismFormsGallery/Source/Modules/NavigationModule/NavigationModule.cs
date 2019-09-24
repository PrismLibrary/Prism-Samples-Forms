using System;
using NavigationModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace NavigationModule
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Console.WriteLine($">>> {GetType().Name} initialized.");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavMainPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();
            containerRegistry.RegisterForNavigation<TabB>();
            containerRegistry.RegisterForNavigation<TabC>();
        }
    }
}
