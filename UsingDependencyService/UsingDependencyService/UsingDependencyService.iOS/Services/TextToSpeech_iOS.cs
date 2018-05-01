using AVFoundation;
using UsingDependencyService.iOS.Services;
using UsingDependencyService.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_iOS))]

namespace UsingDependencyService.iOS.Services
{
    public class TextToSpeech_iOS : ITextToSpeech
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 2.5f,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}