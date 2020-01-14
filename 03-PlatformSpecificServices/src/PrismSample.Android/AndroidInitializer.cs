using Prism;
using Prism.Ioc;
using PrismSample.Droid.Services;
using PrismSample.Services;

namespace PrismSample.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextToSpeech, TextToSpeech_Android>();
        }
    }
}