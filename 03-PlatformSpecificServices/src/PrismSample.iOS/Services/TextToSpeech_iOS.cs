using Xamarin.Essentials;
using PrismSample.Services;
using System.Threading.Tasks;

namespace PrismSample.iOS.Services
{
    public class TextToSpeech_iOS : ITextToSpeech
    {
        public Task Speak(string text)
        {
            return TextToSpeech.SpeakAsync(text);
        }
    }
}