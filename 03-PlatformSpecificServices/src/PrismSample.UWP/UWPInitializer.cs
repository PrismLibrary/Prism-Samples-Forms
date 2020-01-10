using Prism;
using Prism.Ioc;
using PrismSample.Services;
using PrismSample.UWP.Services;

namespace PrismSample.UWP
{
    public class UWPInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextToSpeech, TextToSpeech_UWP>();
        }
    }
}
