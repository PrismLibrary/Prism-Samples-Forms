using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration;
using Prism.Behaviors;
using Xamarin.Forms;

namespace PrismSample.Behaviors
{
    public class SampleBehaviorFactory : PageBehaviorFactory
    {
        public override void ApplyContentPageBehaviors(ContentPage page)
        {
            base.ApplyContentPageBehaviors(page);
            page.Content.BackgroundColor = Color.DarkGray;

            // Platform specific
            page.On<iOS>().SetUseSafeArea(true);
        }

        public override void ApplyTabbedPageBehaviors(Xamarin.Forms.TabbedPage page)
        {
            base.ApplyTabbedPageBehaviors(page);
            page.SetValue(Xamarin.Forms.NavigationPage.BarBackgroundColorProperty, Color.DarkBlue);

            // Platform specific
            page.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}