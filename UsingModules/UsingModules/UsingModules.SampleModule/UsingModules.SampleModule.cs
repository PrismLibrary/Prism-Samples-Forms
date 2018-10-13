using Prism.Ioc;
using Prism.Modularity;
using UsingModules.SampleModule.Views;
using UsingModules.SampleModule.ViewModels;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingModules.SampleModule
{
    public class SampleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SamplePage, SamplePageViewModel>();
        }
    }
}
