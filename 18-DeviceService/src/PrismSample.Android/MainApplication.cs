using System;
using Android.App;
using Android.Runtime;

namespace PrismSample.Droid
{
    [Application(
        Label = "Device Service",
        Icon = "@mipmap/icon"
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}