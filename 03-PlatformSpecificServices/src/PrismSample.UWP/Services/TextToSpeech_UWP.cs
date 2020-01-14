using System;
using System.Threading.Tasks;
using PrismSample.Services;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace PrismSample.UWP.Services
{
    public class TextToSpeech_UWP : ITextToSpeech
    {
        public async Task Speak(string text)
        {
            var player = new MediaElement();
            var synth = new SpeechSynthesizer();
            SpeechSynthesisStream audioStream = await synth.SynthesizeTextToStreamAsync(text);
            player.SetSource(audioStream, audioStream.ContentType);
            player.Play();

        }
    }
}
