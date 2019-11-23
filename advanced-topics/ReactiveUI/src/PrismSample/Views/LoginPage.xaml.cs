using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismSample.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPageBase<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();

            this.Bind(ViewModel, x => x.Username, x => x.Username.Text)
                .DisposeWith(ViewBindings);

            this.Bind(ViewModel, x => x.Password, x => x.Password.Text)
                .DisposeWith(ViewBindings);

            this.BindCommand(ViewModel, x => x.Login, x => x.LoginButton)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.IsLoading, x => x.Loading.IsVisible)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.IsLoading, x => x.Loading.IsRunning)
                .DisposeWith(ViewBindings);

            this.WhenAnyObservable(x => x.ViewModel.Login.CanExecute)
                .StartWith(false)
                .DistinctUntilChanged()
                .Subscribe(canExecute =>
                {
                    LoginButton.BackgroundColor = canExecute ? Color.FromHex("#3897F0") : Color.FromHex("#AFD5F9");
                    LoginButton.TextColor = canExecute ? Color.White : Color.Black;
                });
        }
    }
}