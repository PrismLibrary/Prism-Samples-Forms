using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Events;
using UsingEventAggregator.Models;
using Windows.UI.Popups;

namespace UsingEventAggregator.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var application = new UsingEventAggregator.App(new UwpInitialer());

            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNativeEvent);

            LoadApplication(application);
        }

        private async void OnNativeEvent(NativeEventArgs args)
        {
            var msg = new MessageDialog($"Hi {args.Message}, from Windows");
            await msg.ShowAsync();
        }
    }

    public class UwpInitialer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
        }
    }
}
