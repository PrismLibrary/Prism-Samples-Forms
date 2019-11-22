using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Speech.Tts;
using Plugin.CurrentActivity;
using UsingPlatformSpecificServices.Services;
using Debug = System.Diagnostics.Debug;

namespace UsingPlatformSpecificServices.Droid.Services
{
    public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;
        private ICurrentActivity _currentActivity { get; }

        public TextToSpeech_Android(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;
        }

        public Task Speak(string text)
        {
            return new Task(() =>
            {
                toSpeak = text;
                if (speaker == null)
                {
                    speaker = new TextToSpeech(_currentActivity.Activity, this);
                }
                else
                {
                    var p = new Dictionary<string, string>();
                    speaker.Speak(toSpeak, QueueMode.Flush, p);
                    Debug.WriteLine("spoke " + toSpeak);
                }
            });
            
        }

        #region IOnInitListener implementation

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }

        #endregion
    }

}