# EventToCommand Behavior

The EventToCommandBehavior class provide a convenient way to, in XAML, "bind" events to ICommand according to MVVM paradigm to avoid code behind. [Prism docs]


This sample project, shows you how to use couple of common usages of EventToCommandBehavior in Xamarin.Forms.

* `Views/SimpleExamplePage` on this page you can find the simpliest way to use `EventToCommandBehavior` with `DelegateCommand`.

* `Views/EventArgsConverterExamplePage` on this page you can find usage of `EventToCommandBehavior` in combination with `EventArgsConverter` property and `IValueConverter`.

* `Views/EventArgsConverterExamplePage` on this page you can find usage of `EventToCommandBehavior` in combination with `EventArgsParameterPath` property and `Item` property.

