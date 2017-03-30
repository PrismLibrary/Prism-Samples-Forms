using System;
using Prism.Navigation;
using HamburgerMenu.Helpers;

namespace HamburgerMenu.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        INavigationService _navigationService { get; }

        public AuthenticationService( INavigationService navigationService )
        {
            _navigationService = navigationService;
        }

        public bool Login( string username, string password )
        {
            if ( password.Equals( "prismrocks", StringComparison.OrdinalIgnoreCase ) )
            {
                Settings.Current.UserName = username;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            Settings.Current.UserName = string.Empty;
            _navigationService.NavigateAsync( "/Login" );
        }
    }
}
