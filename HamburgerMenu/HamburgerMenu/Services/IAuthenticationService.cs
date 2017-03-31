using System;
namespace HamburgerMenu.Services
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);

        void Logout();
    }
}
