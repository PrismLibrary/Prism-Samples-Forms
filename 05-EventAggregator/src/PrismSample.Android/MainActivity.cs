using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PrismSample.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            var application = new App();
            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
            LoadApplication(application);
        }

        private void OnNameChangedEvent(NativeEventArgs args)
        {
            Toast.MakeText(this, $"Hi {args.Message}, from Android", ToastLength.Long).Show();
        }
    }
}