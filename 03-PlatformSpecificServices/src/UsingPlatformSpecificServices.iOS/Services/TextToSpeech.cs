using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using UIKit;
using UsingPlatformSpecificServices.Services;

namespace UsingPlatformSpecificServices.iOS.Services
{
    class TextToSpeech : ITextToSpeech
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