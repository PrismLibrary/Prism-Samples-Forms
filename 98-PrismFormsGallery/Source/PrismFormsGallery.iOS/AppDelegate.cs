using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Prism.Events;
using UIKit;
using Prism.Ioc;
using EventsModule.Events;

namespace PrismFormsGallery.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            #region Subscribe to Events on platform

            //var xfApp = new App();
            //xfApp.Container?.Resolve<IEventAggregator>()?.GetEvent<GreetEvent>()?.Subscribe(OnMessageReceived);
            //LoadApplication(xfApp);

            #endregion

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        private void OnMessageReceived(string obj)
        {
            new UIAlertView("iOS", obj, null, "WOW!").Show();
        }
    }
}
