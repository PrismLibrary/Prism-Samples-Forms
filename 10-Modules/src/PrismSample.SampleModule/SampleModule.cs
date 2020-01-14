using Prism.Ioc;
using Prism.Modularity;
using PrismSample.SampleModule.Views;
using PrismSample.SampleModule.ViewModels;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismSample.SampleModule
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
