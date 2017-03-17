using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using UsingDependencyService.UWP.Services;
using UsingDependencyService.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_UWP))]

namespace UsingDependencyService.UWP.Services
{
    public class TextToSpeech_UWP : ITextToSpeech
    {
        public async void Speak(string text)
        {
            var player = new MediaElement();
            var synth = new SpeechSynthesizer();
            SpeechSynthesisStream audioStream = await synth.SynthesizeTextToStreamAsync(text);
            player.SetSource(audioStream, audioStream.ContentType);
            player.Play();
        }
    }
}
