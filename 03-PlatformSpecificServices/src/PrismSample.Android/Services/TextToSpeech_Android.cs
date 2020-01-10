using Xamarin.Essentials;
using PrismSample.Services;
using System.Threading.Tasks;

namespace PrismSample.Droid.Services
{
    public class TextToSpeech_Android : ITextToSpeech
    {
        public Task Speak(string text)
        {
            return TextToSpeech.SpeakAsync(text);
        }
    }
}