using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Prism;
using Prism.Events;
using Prism.Ioc;
using PrismSample.Models;

namespace PrismSample.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var application = new App(new AndroidInitializer());
            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
            LoadApplication(application);
        }

        private void OnNameChangedEvent(NativeEventArgs args)
        {
            Toast.MakeText(this, $"Hi {args.Message}, from Android", ToastLength.Long).Show();
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}