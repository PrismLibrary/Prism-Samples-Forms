using System;
using EventsModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace EventsModule
{
    public class EventsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Console.WriteLine($">>> {GetType().Name} initialized.");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EventPage>();
            containerRegistry.RegisterForNavigation<EventPublisherPage>();
        }
    }
}
