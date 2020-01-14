using Prism.Ioc;
using PrismSample.Services;
using PrismSample.Views;
using Xamarin.Forms;

namespace PrismSample
{
    [AutoRegisterForNavigation]
    public partial class App
    {
        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync($"NavigationPage/MainPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterDialog<TermsDialog>();
            containerRegistry.RegisterDialog<LockingDialog>();
            containerRegistry.RegisterDialog<NameDialog>();
            containerRegistry.RegisterDialog<ContactSelectorDialog>();

            containerRegistry.Register<IContactsService, ContactsService>();
        }
    }
}
