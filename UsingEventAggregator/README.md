# Using EventAggregator

### Usage
#### Named Events
Custom event with primitive payload

```csharp
public class IsFunChangedEvent : PubSubEvent<bool> { }
```

##### Subcribe

`_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);`

Event handler,
`void IsFunChanged(bool arg) { }`

##### Publish
`_eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (true);`

#### Generic Events
Custom event with generic payload

`public class GenericEvent<T> : PubSubEvent<T> { }`

##### Subcribe

`_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);`

Event handler,
`void NameChanged(string name) { }`

##### Publish
`_eventAggregator.GetEvent<GenericEvent<string>> ().Publish ("John Doe");`

#### Native Events
Custom event with custom payload

Custom payload,
```
public class NativeEventArgs : EventArgs
{
    public string Message { get; set; }
    public NativeEventArgs (string message)
    {
        Message = message;
    }
}
```
`public class NativeEvent : PubSubEvent<NativeEventArgs> { }`

##### Subcribe

###### iOS
`_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);`

Event handler,
`void NameChanged(string name) { }`

###### Android
`_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);`

Event handler,
`void NameChanged(string name) { }`

###### UWP
`_eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);`

Event handler,
`void NameChanged(string name) { }`

##### Publish
`_eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));`

