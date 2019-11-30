using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Util;

namespace PrismFormsGallery.Droid
{
    [Activity(Theme = "@style/SplashScreen",
              MainLauncher = true,
              NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartMainActivity();
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        void StartMainActivity()
        {
            StartActivity(new Intent(BaseContext, typeof(MainActivity)));
        }
    }
}