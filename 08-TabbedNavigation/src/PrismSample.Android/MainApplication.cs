using System;
using Android.App;
using Android.Runtime;

namespace PrismSample.Droid
{
    [Application(
        Label = "Tabbed Navigation",
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