using System;
using CommandingModule.Views;
using Prism.Ioc;
using Prism.Modularity;
namespace CommandingModule
{
    public class CommandingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Console.WriteLine($">>> {GetType().Name} initialized.");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
        }
    }
}
