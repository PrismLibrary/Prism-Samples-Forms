# Using ReactiveUI + Prism

- Use Prism Navigation Paradigms + DI
- Use ReactiveCommands
- Use ReactiveObject for the ViewModel's base class

Borrowed Instagram UI for Xamarin.Forms from [Adam Pedley](https://github.com/adamped/Instagram)

### Uses the following ReactiveUI concepts

- [WhenAny](https://reactiveui.net/docs/handbook/when-any/)
    - Value
    - Observable
- [Binding Type Converters](https://reactiveui.net/docs/handbook/data-binding/value-converters)
- [Pharmacist Events to Observables](https://github.com/reactiveui/pharmacist#how-do-i-use)
    - Generates observables from events
    - [Observable.FromEvent](https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh229241(v=vs.103))
- [Observable As Property Helper](https://reactiveui.net/docs/handbook/observable-as-property-helper/)    
- ReactiveUI Bindings
    - [Inline type conversion](https://reactiveui.net/docs/handbook/data-binding/value-converters#inline-binding-converters)
- Data Load
     - Loading data in response to notify property changed
- Reactive Command
    - Can execute based on an observable
    - Binding `IsExecuting` to ActivityIndicator
    - [Bind output to a property](https://reactiveui.net/docs/handbook/commands/#asynchronous-commands)
- Reactive Extension Operators
    - [DistinctUntilChanged](http://reactivex.io/documentation/operators/distinct.html)
    - [StartWith](http://reactivex.io/documentation/operators/startwith.html)
    - [Subscribe](http://reactivex.io/documentation/operators/subscribe.html)
    - [Throttle](http://reactivex.io/documentation/operators/debounce.html)
