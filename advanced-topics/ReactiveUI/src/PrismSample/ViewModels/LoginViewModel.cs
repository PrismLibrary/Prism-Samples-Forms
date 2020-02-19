using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using PrismSample.Views;
using ReactiveUI;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class LoginViewModel : NavigationViewModelBase
    {
        private readonly ObservableAsPropertyHelper<bool> _isLoading;
        private readonly INavigationService _navigationService;
        private string _username;
        private string _password;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // set the canExecute to an observable of two properties selector.
            var canExecuteLogin =
                this.WhenAnyValue(
                    x => x.Username, 
                    x => x.Password, 
                    (username, password) =>
                        ValidateEmail(username) && ValidatePassword(password));

            Login = ReactiveCommand.CreateFromTask(ExecuteLogin, canExecuteLogin);

            _isLoading =
                this.WhenAnyObservable(x => x.Login.IsExecuting)
                    .ToProperty(this, x => x.IsLoading, initialValue: false);
        }

        public ReactiveCommand<Unit, Unit> Login { get; set; }

        public bool IsLoading => _isLoading.Value;

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        private async Task ExecuteLogin()
        {
            await Observable.Return(Unit.Default).Delay(TimeSpan.FromSeconds(3));
            await _navigationService.NavigateAsync($"NavigationPage/NuGetPackageListPage");
        }

        private static bool ValidateEmail(string email) => !string.IsNullOrEmpty(email) && email.Length > 2;

        private static bool ValidatePassword(string password) => !string.IsNullOrEmpty(password) && password.Length > 5;
    }
}