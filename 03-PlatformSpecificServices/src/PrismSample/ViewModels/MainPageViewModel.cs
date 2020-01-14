using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using PrismSample.Services;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private ITextToSpeech _textToSpeech { get; }

        public MainPageViewModel(ITextToSpeech textToSpeech, IDeviceService device)
        {
            _textToSpeech = textToSpeech;
            SpeakCommand = new DelegateCommand(OnSpeakCommandExecuted, () => !IsExecuting && !string.IsNullOrEmpty(Text))
                .ObservesProperty(() => IsExecuting)
                .ObservesProperty(() => Text);

            Text = $"This text will be spoken by {device.RuntimePlatform}";
        }

        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set => SetProperty(ref _isExecuting, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public DelegateCommand SpeakCommand { get; }

        private void OnSpeakCommandExecuted()
        {
            _textToSpeech.Speak(Text);
        }
    }
}
