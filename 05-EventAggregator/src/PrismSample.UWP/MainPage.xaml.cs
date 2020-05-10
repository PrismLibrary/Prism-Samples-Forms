using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Ioc;
using Prism.Events;
using PrismSample.Models;
using Windows.UI.Popups;

namespace PrismSample.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var application = new PrismSample.App();

            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNativeEvent);

            LoadApplication(application);
        }

        private async void OnNativeEvent(NativeEventArgs args)
        {
            var msg = new MessageDialog($"Hi {args.Message}, from Windows");
            await msg.ShowAsync();
        }
    }
}
