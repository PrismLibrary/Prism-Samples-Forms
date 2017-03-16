using System;
using UsingDependencyService.UWP.Services;
using UsingDependencyService.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_UWP))]

namespace UsingDependencyService.UWP.Services
{
    public class TextToSpeech_UWP : ITextToSpeech
    {
        public void Speak(string text)
        {
            //TODO: Need to create UWP Speak() implementation -
            //  probably need code from here:  https://docs.microsoft.com/en-us/uwp/api/Windows.Media.SpeechSynthesis.SpeechSynthesizer
            throw new NotImplementedException();
        }
    }
}
