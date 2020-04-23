using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Util;

namespace PrismSample.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", 
              MainLauncher = true, 
              NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
