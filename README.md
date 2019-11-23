# Prism Samples Forms

Samples that demonstrate how to use various Prism features with Xamarin.Forms.

## Learning Prism

Learn feature by feature how to use Prism in your apps!

| # | Sample | Description |
|:-:|:------:|-------------|
| 1 | [Prism Navigation][NavigationSample] | How to use Prism's Uri based navigation to reset the navigation stack, or add pages Modally or Non-Modally |
| 2 | [Registering Services][ServiceRegistrationSample] | How to use IContainerRegistry to register services to act as Singletons or Transients within your application. |
| 3 | [Platform Specific Services][PlatformSpecificServiceSample] | How to use Prism to auto inject platform specific dependencies that are registered with the IPlatformInitializer. |
| 4 | [Delegate Commands][DelegateCommandSample] | How to use DelegateCommands and ObservesCanExecute |
| 4.1 | [Composite Commands][CompositeCommandSample] | How to use CompositeCommands to invoke commands in multiple unrelated ViewModels from a single interaction. |
| 5 | [Event Aggregator][EventAggregatorSample] | How to use the IEventAggregator to raise and listen to events. This shows how to use a simple event with a primitive type payload, generic event with payload &lt;T&gt;, and event with custom EventArgs. It also demonstrated how to subscribe to events published in Xamarin.Forms inside native code. |
| 6 | [Page Dialog Service][PageDialogServiceSample] | How to use the IPageDialogService to display alerts and action sheets from within your ViewModels. |
| 7 | [Dialog Service][DialogServiceSample] | How to use the DialogService to provide highly customizable experiences within your application. |
| 8 | [Tabbed Navigation][8] | coming soon |
| 9 | [Master Detail][9] | coming soon |
| 10 | [Modules][ModulesSample] | How to use Prism modularization to separate the application logic using IModule, IModuleManager, ModuleCatalog. |
| 11 | [Module Dependency][ModuleDependencySample] | coming soon |
| 12 | [ViewModelLocator][ViewModelLocatorSample] | coming soon |
| 13 | [ViewModel Initialization][ViewModelInitailizationSample] | How to properly use `IAutoInitialize`, `IInitialize`, or `IInitializeAsync` to do a one time initialization of your ViewModel with the context you need based on the Navigation Parameters, or any other initialization you may need to do. |
| 14 | [EventToCommandBehavior][EventToCommandSample] | How to use the `EventToCommandBehavior` to bind to ViewModel Commands even when there is no Command property on an element. |
| 15 | [PageBehaviorFactory][PageBehaviorFactorySample] | coming soon |
| 16 | [PageLifecycleAware][PageLifecycleSample] | How use `IPageLifecycleAware` to execute code in your ViewModel when the Page appears / disappears. |
| 17 | [XamlNavigation][XamlNavigationSample] | How to do Prism navigation from within Xaml |
| 18 | [DeviceService][DeviceServiceSample] | How to use Prism's IDeviceService to get the device's runtime and idiom. |
| 19 | [NavigationMode][NavigationModeSample] | How to use the NavigationMode enum to only act on something when navigating back to a view |
| 20 | [Confirm Navigation][ConfirmNavigationSample] | coming soon |

## Advanced Concepts

| Sample | Description |
| ------ |-------------|
| [Popups Plugin][PopupsPluginSample] | Quite often you may find that a Modal page just doesn't cut it. A very popular option is to use Rg.Plugins.Popup. Because this is a 3rd party plugin it requires the use of [Prism.Plugins.Popup](https://popups.prismplugins.com). This sample shows how to use both Popup Pages for the Dialog Service and with Prism's Navigation Service. |
| [Logging with App Center][AppCenterLoggingSample] | coming soon |
| [Logging with Syslog][SyslogLoggingSample] | coming soon |
| [Logging with Loggly][LogglyLoggingSample] | Walks you through using the Logging Plugin with Loggly for Syslog or Http |
| [Using Shiny Lib + Prism][ShinyPrismSample] | coming soon |
| [Using ReactiveUI + Prism][ReactiveUISample] | coming soon |

## Sample Apps

| Sample | Description |
| ---------- |-------------|
| [Prism Forms Gallery][PrismFormsGallery] | Prism.Forms Gallery demonstrates a number of Prism and Prism.Forms features all in a single app. The goal of this gallery is to make it easy to learn, share, teach, test, and use the material in your presentations and talks. |
| [Contoso Cookbook][ContosoCookbook] | Contoso Cookbook is a classic Microsoft sample recipe app; first adapted for Xamarin.Forms by Jeff Prosise in 2015 and now updated to use Prism for Xamarin.Forms. Demonstrates how to use a TabbedPage with a DataTemplate for the tabs, and a ListView with DataTemplate for the recipe list on each tab; for a clean professional-looking UI. |

## Adding or Updating a Sample

A number of topics have been stubbed out. For any existing topic you can simply update the project with the relavent content. Be sure the Project heads are each updated as follows:

- The Display Name on iOS, Android and UWP should be updated from `Prism Sample` to be relevent to what your sample is on. It should also be short! (i.e. ViewModelInitialization -&gt; Prism Init, EventToCommandBehavior -&gt; Event 2 Cmd)
- Please do not change any existing colors or styles. You may add colors / styles if they help but the samples are generally meant to be simple.
- The Sample's all use `com.prismlibrary.prismsample` as the Bundle/Package Id. If every sample kept this you would not be able to have samples side by side. Be sure that the final segment `prismsample` is updated to the lowercase name of the sample (i.e. `com.prismlibrary.eventtocommand`)

If you're adding a brand new sample be sure to start with a copy of the resources in the [Sample Template](sample-template/) directory.

[NavigationSample]: 01-Navigation/
[ServiceRegistrationSample]: 02-ServiceRegistration/
[PlatformSpecificServiceSample]: 03-PlatformSpecificServices/
[DelegateCommandSample]: 04-Commands/
[CompositeCommandSample]: 04-CompositeCommands/
[EventAggregatorSample]: 05-EventAggregator/
[PageDialogServiceSample]: 06-PageDialogService/
[DialogServiceSample]: 07-DialogService/
[8]: 08-TabbedNavigation/
[9]: 09-MasterDetail/
[ModulesSample]: 10-Modules/
[ModuleDependencySample]: 11-ModuleDependency/
[ViewModelLocatorSample]: 12-ViewModelLocator/
[ViewModelInitailizationSample]: 13-ViewModelInitialization/
[EventToCommandSample]: 14-EventToCommandBehavior/
[PageBehaviorFactorySample]: 15-PageBehaviorFactory/
[PageLifecycleSample]: 16-PageLifecycleAware/
[XamlNavigationSample]: 17-XamlNavigation/
[DeviceServiceSample]: 18-DeviceService/
[NavigationModeSample]: 19-NavigationMode/
[ConfirmNavigationSample]: 20-ConfirmNavigation/

[PopupsPluginSample]: advanced-topics/PopupsPlugin/
[AppCenterLoggingSample]: advanced-topics/Logging-AppCenter/
[SyslogLoggingSample]: advanced-topics/Logging-Syslog/
[LogglyLoggingSample]: advanced-topics/Logging-Loggly/
[ShinyPrismSample]: advanced-topics/ShinyLib/
[ReactiveUISample]: advanced-topics/ReactiveUI/

[PrismFormsGallery]: sample-apps/PrismFormsGallery
[ContosoCookbook]: sample-apps/ContosoCookbook
