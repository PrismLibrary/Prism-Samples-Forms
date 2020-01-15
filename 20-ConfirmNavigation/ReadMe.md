# Confirm Navigation

* **ViewAPage** is tab page, and it contains `Switch` and `Button` control, `Switch` is binding to `CanNavigateAway` property. `ViewAPageViewModel ` is implementing `IConfirmNavigation` interface and `CanNavigateAway` is used for returning value in `CanNavigate` method.

* **ViewBPage** is tab page, and it contains `Button`, `Button` and `Command` property is binding to `NavigateAwayCommand`. `ViewBPageViewModel` is implementing `IConfirmNavigationAsync` interface and I am using `IPageDialogService` to ask user for confirm to navigate away, response from `DisplayAlertAsync` is used for return value of `CanNavigateAsync` method.

* **ViewCPage** is only used for navigating to it, and to show some kind of message with `Label` control. It also has `Button` to navigate back (GoBacAsync).