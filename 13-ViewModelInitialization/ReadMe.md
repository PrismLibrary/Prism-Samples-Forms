# ViewModel Initialization

ViewModel initialization occurs only Once during the lifecycle of the ViewModel. For Prism ViewModels we initialize our ViewModel, or make it ready to use in one of two ways. The first way is we initialize any generic state for our ViewModel within our constructor. We can use Dependency Injection here to provide services which our ViewModel will depend on, we might also initialize Commands, and certain other properties within the ViewModel.

Where many developers get more confused is with the second way we need to initialize our ViewModel in which the ViewModel needs the proper context of how we will be using the ViewModel. Most commonly we may get much of this context via the Navigation Parameters. Prism provides us a few ways to handle this second variation.

## YouTube Tutorials

Using IInitialize:
[![Using IInitialize](http://img.youtube.com/vi/uGDflfthMeA/0.jpg)](http://www.youtube.com/watch?v=uGDflfthMeA "Initializing your ViewModels with IInitialize")

## IAutoInitialization

When running the sample you'll see that we can keep our ViewModel very lightweight and simply add the marker interface `IAutoInitialize`. The NavigationService will do the rest and automatically use the NavigationParameters to set properties within the ViewModel for us. We can optionally add the `AutoInitialize` attribute to our properties if we need to mark a property as being required or having a completely different name than the property name.

## IInitialize

For all the times where you need to execute some custom business logic as part of the initialization process, you can use IInitialize to perform synchronous code blocks.

## IInitializeAsync

Probably the single most misused API is any API that says Async. You'll notice that there are three ViewModels that execute a long running task during their initialization, however they only ViewC uses `IInitializeAsync`. Async code blocks will always be awaited by the Prism Navigation Service. When we navigate from the MainPage to ViewC you'll notice that there is a long delay before ViewC finally appears because we ensure that the ViewModel is fully initialized by awaiting it's `InitializeAsync` method.

On the other hand this would not be acceptable behavior for the first page or our App. For the case of the MainPageViewModel we instead simply use `IInitialize` and use `async void` to ensure that this will be a non-blocking async code block. This allows us to quickly navigate to the MainPage, however it does mean any exceptions will need to be handled within that block as we will not be able to catch and return any exceptions within the NavigationService, which we can see an example of with ViewD.