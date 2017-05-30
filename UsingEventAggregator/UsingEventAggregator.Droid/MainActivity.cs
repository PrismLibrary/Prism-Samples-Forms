using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Events;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.Droid
{
    [Activity (Label = "UsingEventAggregator.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            global::Xamarin.Forms.Forms.Init (this, bundle);

            var application = new App (new AndroidInitializer ());

            var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent> ().Subscribe (OnNameChangedEvent);

            LoadApplication (application);
        }

        private void OnNameChangedEvent (NativeEventArgs args)
        {
            Toast.MakeText (this, $"Hi {args.Message}, from Android", ToastLength.Long).Show ();
        }
   }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes (IUnityContainer container)
        {

        }
    }
}
