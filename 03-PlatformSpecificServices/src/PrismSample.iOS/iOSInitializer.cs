using Prism;
using Prism.Ioc;
using PrismSample.iOS.Services;
using PrismSample.Services;

namespace PrismSample.iOS
{
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextToSpeech, TextToSpeech_iOS>();
        }
    }
}
