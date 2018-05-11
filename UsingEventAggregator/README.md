# EventAggregator 
Prism offers `EventAggregator` to send and recieve events throughout your application. It provides several benefits e.g.,
- An abstraction `IEventAggregator` to keep your code testable
- It is Memory safe as it holds weak reference to subscriptions
- It simplifies subcription and publishing (no need to pass sender objects, event names, etc.)

It is a better alternative to Xamarin's built-in `MessagingCenter` which is a static service that makes code hard to test.
# Using EventAggregator
In this sample, we will see how to create custom events, how to pass custom payload in events, how to subscribe to events both inside Xamarin.Forms app and on the native platform, and how to publish events all using Prism's EventAggregator.

## Creating Events
To create an event, simply extend `Prism.Events.PubSubEvent`,

```csharp
public class FormSubmittedEvent : PubSubEvent { }
```
### Usage
#### Publish
```csharp
_eventAggregator.GetEvent<FormSubmittedEvent>().Publish ();
```
#### Subcribe
```csharp
_eventAggregator.GetEvent<FormSubmittedEvent> ().Subscribe (OnFormSubmitted);

void OnFormSubmitted() 
{
    // Do something
}
```

## Creating Events with Payload
To create an event and send a payload/data, extend `Prism.Events.PubSubEvent<T>` with `T` payload.
```csharp
public class IsFunChangedEvent : PubSubEvent<bool> { }
```
### Usage
#### Publish
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (true);
```
#### Subcribe
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) 
{
    // Do something with the payload
}
```

## Creating Events with Custom Payload
To create a custom payload for your event, simply extend `System.EventArgs` and set as payload for custom event,
```csharp
public class NativeEventArgs : EventArgs
{
    public string Message { get; set; }
    public NativeEventArgs (string message)
    {
        Message = message;
    }
}

public class NativeEvent : PubSubEvent<NativeEventArgs> { }
```
### Usage
#### Publish
```csharp
_eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));
```

#### Subcribe
```csharp
_eventAggregator.GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);

void OnNameChangedEvent(NativeEventArgs args) 
{
    Message = args.Message;
}
```

## Subscribing To Events
### Shared Subscriptios
As mentioned above, subscribing to events is quite simple inside Xamarin.Forms app.
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) 
{
    // Do something with the payload
}
```
### Platform Subscriptions
For events that need subscription at the platform level, resolve the `IEventAggregator` from the `Xamarin.Forms.App()` instance before loading application.

### iOS
After initializing the Xamarin.Forms app in `FinishedLaunching()` method of `AppDelegate.cs`,
```csharp
var application = new App (new iOSInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
LoadApplication (application);
```

### Android
After initializing the Xamarin.Forms app in `OnCreate()` method of `MainActivity.cs`,
```csharp
var application = new App (new AndroidInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent> ().Subscribe (OnNameChangedEvent);
LoadApplication (application);
```

### UWP
After initializing the Xamarin.Forms app in `OnLaunched()` method of native `App.xaml.cs`, subsribe in the contructor of `MainPage.xaml.cs`,
```csharp
var application = new UsingEventAggregator.App(new UwpInitialer());
var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNativeEvent);
LoadApplication(application);
```