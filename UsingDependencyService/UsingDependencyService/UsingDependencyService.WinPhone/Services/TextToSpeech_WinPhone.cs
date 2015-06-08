using System;
using Windows.Phone.Speech.Synthesis;
using UsingDependencyService.Services;
using UsingDependencyService.WinPhone.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_WinPhone))]

namespace UsingDependencyService.WinPhone.Services
{
    public class TextToSpeech_WinPhone : ITextToSpeech
    {
        public async void Speak(string text)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            await synth.SpeakTextAsync(text);
        }
    }
}
