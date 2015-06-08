using Xamarin.Forms;

namespace UsingDependencyService
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            Bootstrapper bs = new Bootstrapper();
            bs.Run(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
