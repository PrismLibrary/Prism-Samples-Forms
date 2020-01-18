using System;
using Android.App;
using Android.Runtime;

namespace PrismFormsGallery.Droid
{
    [Application(Label = "Prism Gallery",
                 Icon = "@mipmap/icon")]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}