using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using PrismSample.Services;
using UIKit;

namespace PrismSample.iOS.Services
{
    public class TextToSpeech_iOS : ITextToSpeech
    {
        public Task Speak(string text)
        {
            return new Task(() =>
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
            });
        }
    }
}