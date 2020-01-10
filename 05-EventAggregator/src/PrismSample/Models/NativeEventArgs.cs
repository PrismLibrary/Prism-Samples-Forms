using System;
namespace PrismSample.Models
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
