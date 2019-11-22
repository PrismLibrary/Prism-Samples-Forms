using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingPlatformSpecificServices.Services;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace UsingPlatformSpecificServices.UWP.Services
{
    class TextToSpeech : ITextToSpeech
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
