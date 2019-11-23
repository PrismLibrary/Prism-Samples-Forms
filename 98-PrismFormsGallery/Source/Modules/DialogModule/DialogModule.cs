using System;
using DialogModule.ViewModels;
using DialogModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace DialogModule
{
    public class DialogModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Console.WriteLine($">>> {GetType().Name} initialized.");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegistrationView>();
            containerRegistry.RegisterDialog<TermsDialogView, TermsDialogViewModel>();
        }
    }
}
