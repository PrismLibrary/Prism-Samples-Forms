using Prism.Commands;
using Prism.Mvvm;
using UsingDependencyService.Services;

namespace UsingDependencyService.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly ITextToSpeech _textToSpeech;

        private string _textToSay = "Hello from Xamarin Forms and Prism.";
        public string TextToSay
        {
            get { return _textToSay; }
            set { SetProperty(ref _textToSay, value); }
        }

        public DelegateCommand SpeakCommand { get; set; }

        public MainPageViewModel(ITextToSpeech textToSpeech)
        {
            _textToSpeech = textToSpeech;
            SpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            _textToSpeech.Speak(TextToSay);
        }
    }
}
