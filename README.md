# Prism Samples Forms

Samples that demonstrate how to use various Prism features with Xamarin.Forms.

## Learning Prism

Learn feature by feature how to use Prism in your apps!

| # | Sample | Description |
|:-:|:------:|-------------|
| 1 | [Prism Navigation][1] | How to use Prism's Uri based navigation to reset the navigation stack, or add pages Modally or Non-Modally |
| 2 | [Registering Services][2] | coming soon |
| 3 | [Platform Specific Services][3] | How to use Prism to auto inject platform specific dependencies that are registered with the IPlatformInitializer. |
| 4 | [Delegate Commands][4] | How to use DelegateCommands and ObservesCanExecute |
| 4.1 | [Composite Commands][4_1] | How to use CompositeCommands to invoke commands in multiple unrelated ViewModels from a single interaction. |
| 5 | [Event Aggregator][5] | How to use the IEventAggregator to raise and listen to events. This shows how to use a simple event with a primitive type payload, generic event with payload &lt;T&gt;, and event with custom EventArgs. It also demonstrated how to subscribe to events published in Xamarin.Forms inside native code. |
| 6 | [Page Dialog Service][6] | How to use the IPageDialogService to display alerts and action sheets from within your ViewModels. |
| 7 | [Dialog Service][7] | coming soon |
| 8 | [Tabbed Navigation][8] | How to do navigation with tabbed pages in Prism |
| 9 | [Master Detail][9] | coming soon |
| 10 | [Modules][10] | How to use Prism modularization to separate the application logic using IModule, IModuleManager, ModuleCatalog. |
| 11 | [Module Dependency][11] | coming soon |
| 12 | [ViewModelLocator][12] | coming soon |
| 13 | [ViewModel Initialization][13] | coming soon |
| 14 | [EventToCommandBehavior][14] | coming soon |
| 15 | [PageBehaviorFactory][15] | coming soon |
| 16 | [PageLifecycleAware][16] | coming soon |
| 17 | [XamlNavigation][17] | coming soon |
| 18 | [DeviceService][18] | coming soon |
| 19 | [NavigationMode][19] | coming soon |
| 20 | [Confirm Navigation][20] | coming soon |

## Advanced Concepts

| Sample | Description |
| ------ |-------------|
| [Popups Plugin][50] | Quite often you may find that a Modal page just doesn't cut it. A very popular option is to use Rg.Plugins.Popup. Because this is a 3rd party plugin it requires the use of [Prism.Plugins.Popup](https://popups.prismplugins.com). This sample shows how to use both Popup Pages for the Dialog Service and with Prism's Navigation Service. |
| [Logging with App Center][51] | coming soon |
| [Logging with Syslog][52] | coming soon |
| [Logging with Loggly][53] | coming soon |
| [Using Shiny Lib + Prism][60] | coming soon |
| [Using ReactiveUI + Prism][61] | coming soon |

## Sample Apps

| Sample | Description |
| ---------- |-------------|
| [Prism Forms Gallery][98] | Prism.Forms Gallery demonstrates a number of Prism and Prism.Forms features all in a single app. The goal of this gallery is to make it easy to learn, share, teach, test, and use the material in your presentations and talks. |
| [Contoso Cookbook][99] | Contoso Cookbook is a classic Microsoft sample recipe app; first adapted for Xamarin.Forms by Jeff Prosise in 2015 and now updated to use Prism for Xamarin.Forms. Demonstrates how to use a TabbedPage with a DataTemplate for the tabs, and a ListView with DataTemplate for the recipe list on each tab; for a clean professional-looking UI. |

## Adding or Updating a Sample

A number of topics have been stubbed out. For any existing topic you can simply update the project with the relavent content. Be sure the Project heads are each updated as follows:

- The Display Name on iOS, Android and UWP should be updated from `Prism Sample` to be relevent to what your sample is on. It should also be short! (i.e. ViewModelInitialization -&gt; Prism Init, EventToCommandBehavior -&gt; Event 2 Cmd)
- The Sample's all use `com.prismlibrary.prismsample` as the Bundle/Package Id. If every sample kept this you would not be able to have samples side by side. Be sure that the final segment `prismsample` is updated to the lowercase name of the sample (i.e. `com.prismlibrary.eventtocommand`)

If you're adding a brand new sample be sure to start with a copy of the resources in the [Sample Template](sample-template/) directory.

[1]: 01-Navigation/
[2]: 02-ServiceRegistration/
[3]: 03-PlatformSpecificServices/
[4]: 04-Commands/
[4_1]: 04-CompositeCommands/
[5]: 05-EventAggregator/
[6]: 06-PageDialogService/
[7]: 07-DialogService/
[8]: 08-TabbedNavigation/
[9]: 09-MasterDetail/
[10]: 10-Modules/
[11]: 11-ModuleDependency/
[12]: 12-ViewModelLocator/
[13]: 13-ViewModelInitialization/
[14]: 14-EventToCommandBehavior/
[15]: 15-PageBehaviorFactory/
[16]: 16-PageLifecycleAware/
[17]: 17-XamlNavigation/
[18]: 18-DeviceService/
[19]: 19-NavigationMode/
[20]: 20-ConfirmNavigation/

[50]: 50-PopupsPlugin/
[51]: 51-Logging-AppCenter/
[52]: 52-Logging-Syslog/
[53]: 53-Logging-Loggly/
[60]: 60-ShinyLib/
[61]: 61-ReactiveUI/

[98]: 98-PrismFormsGallery
[99]: 99-ContosoCookbook
