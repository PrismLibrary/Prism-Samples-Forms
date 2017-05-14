using System;
namespace UsingEventAggregator.Models
{
    public class NativeEventArgs : EventArgs
    {
        public string Message { get; set; }

        public NativeEventArgs (string message)
        {
            Message = message;
        }
    }
}
