using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using Prism.Modularity;
using PrismFormsGallery.Views;

namespace PrismFormsGallery
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            InitializeComponent();
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync($"NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ModulesPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
			moduleCatalog.AddModule<CommandingModule.CommandingModule>();
            moduleCatalog.AddModule<EventsModule.EventsModule>(InitializationMode.OnDemand);
            moduleCatalog.AddModule<NavigationModule.NavigationModule>(InitializationMode.OnDemand);
            moduleCatalog.AddModule<DialogModule.DialogModule>(InitializationMode.WhenAvailable);
        }
    }
}
