using System;
using Prism;
using Prism.Events;
using Prism.Ioc;
using UsingEventAggregator.Models;
using Windows.UI.Popups;

namespace UsingEventAggregator.UWP
{
    public sealed partial class MainPage : IPlatformInitializer
    {
        public MainPage()
        {
            this.InitializeComponent();

            var application = new UsingEventAggregator.App(this);

            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNativeEvent);

            LoadApplication(application);
        }

        private async void OnNativeEvent(NativeEventArgs args)
        {
            var msg = new MessageDialog($"Hi {args.Message}, from Windows");
            await msg.ShowAsync();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
