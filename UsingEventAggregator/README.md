# Using EventAggregator
In this sample, we will see how to create custom events, how to pass custom payload in events, how to subscribe to events both inside Xamarin.Forms app and on the native platform, and how to publish events all using Prism's EventAggregator.

## Creating Events
To create an event, simply extend `Prism.Events.PubSubEvent<T>` with a T payload.

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
To create a custom payload for your event, simply extend `System.EventArgs`
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
As mentioned avobe, subscribing to events is quite simple inside Xamarin.Forms app.
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) 
{
    // Do something with the payload
}
```
### Platform Subscriptions
To subscribe to an event published in Xamarin.Forms app at the platform level, resolve the `IEventAggregator` from the Xamarin.Forms.App() instance before loading it.

### iOS
After initializing the Xamarin.Forms app in `FinishedLaunching()` method of `AppDelegate.cs`,
```csharp
var application = new App (new iOSInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
LoadApplication (application);
```

### Android
```csharp
var application = new App (new AndroidInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent> ().Subscribe (OnNameChangedEvent);
LoadApplication (application);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

### UWP
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

## Publishing Events
```csharp

```

