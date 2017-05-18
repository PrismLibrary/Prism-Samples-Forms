# Using EventAggregator
In this sample, we will see how to create custom events, how to pass custom payload in events, how to subscribe to events both inside Xamarin.Forms app and on the native platform, and how to publish events all using Prism's EventAggregator.

## Creating Events
To create an event, simply extend `Prism.Events.PubSubEvent<T>` with a T payload.

```csharp
public class IsFunChangedEvent : PubSubEvent<bool> { }
```
### Usage
#### Subcribe

```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) { }
```

#### Publish
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (true);
```

## Creating Events with Custom Payload
Custom event with generic payload

```csharp
public class GenericEvent<T> : PubSubEvent<T> { }
```
### Usage
##### Subcribe

```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

##### Publish
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Publish ("John Doe");
```

## Subscribing To Events
Custom event with custom payload

Custom payload,
```csharp
public class NativeEventArgs : EventArgs
{
    public string Message { get; set; }
    public NativeEventArgs (string message)
    {
        Message = message;
    }
}
```
```csharp
public class NativeEvent : PubSubEvent<NativeEventArgs> { }
```
### iOS
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

### Android
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
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
_eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));
```

