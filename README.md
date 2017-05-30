# Prism Samples Forms
Samples that demonstrate how to use various Prism features with Xamarin.Forms.

| Solution | Description |
-----------|-------------|
| [UsingCompositeCommands][1] |How to use CompositeCommands to invoke commands in multiple unrelated ViewModels from a single interaction.
| [UsingDependencyService][2] |How to use Prism to auto inject platform specific dependencies that are registered with Xamarin.Forms DependencyService.
| [UsingPageDialogService][3] |How to use the IPageDialogService to display alerts and action sheets from within your ViewModels.
| [UsingModules][4] |How to use Prism modularization to separate the application logic using IModule, IModuleManager, ModuleCatalog.
| [UsingEventAggregator][5] |How to use the IEventAggregator to raise and listen to events. This shows how to use a simple event with a primitive type payload, generic event with payload <T>, and event with custom EventArgs. It also demonstrated how to subscribe to events published in Xamarin.Forms inside native code.
| [TabbedNavigation][6] |How to handle TabbedPages. This shows the use of IActiveAware on all Tabbed Children to handle the Switching Tabs, as well as initialization with INavigatingAware, and a strategy for Dynamic Loading of Children in the TabbedPage.
| [ContosoCookbook][7] |Contoso Cookbook is a classic Microsoft sample recipe app; first adapted for Xamarin.Forms by Jeff Prosise in 2015 and now updated to use Prism for Xamarin.Forms. Demonstrates how to use a TabbedPage with a DataTemplate for the tabs, and a ListView with DataTemplate for the recipe list on each tab; for a clean professional-looking UI.





[1]: UsingCompositeCommands/
[2]: UsingDependencyService/
[3]: UsingPageDialogService/
[4]: UsingModules/
[5]: UsingEventAggregator/
[6]: TabbedNavigation/
[7]: ContosoCookbook/



