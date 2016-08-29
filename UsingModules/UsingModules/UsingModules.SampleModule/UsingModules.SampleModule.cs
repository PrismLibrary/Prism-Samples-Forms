using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using UsingModules.SampleModule.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingModules.SampleModule
{
    public class SampleModule : IModule
    {
        private readonly IUnityContainer _unityContainer;
        public SampleModule(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void Initialize()
        {
            _unityContainer.RegisterTypeForNavigation<SamplePage>();
        }
    }
}
