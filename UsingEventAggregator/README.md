# Using EventAggregator

### Usage
#### Named Events
Custom event with primitive payload

```csharp
public class IsFunChangedEvent : PubSubEvent<bool> { }
```

##### Subcribe

```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);
```

Event handler,
```csharp
void IsFunChanged(bool arg) { }
```

##### Publish
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (true);
```

#### Generic Events
Custom event with generic payload

```csharp
public class GenericEvent<T> : PubSubEvent<T> { }
```

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

#### Native Events
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

##### Subcribe

###### iOS
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

###### Android
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

###### UWP
```csharp
_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
```

Event handler,
```csharp
void NameChanged(string name) { }
```

##### Publish
```csharp
_eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));
```

