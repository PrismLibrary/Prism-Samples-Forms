using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Prism;
using Prism.Ioc;
using Prism.Events;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.Droid
{
    [Activity (Label = "Using Event Aggregator", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
