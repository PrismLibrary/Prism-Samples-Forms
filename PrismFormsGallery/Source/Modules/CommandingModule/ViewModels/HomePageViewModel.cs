using System;
using Prism.Commands;

namespace CommandingModule.ViewModels
{
    public class HomePageViewModel : MvvmHelpers.BaseViewModel
    {
        public HomePageViewModel()
        {
            Title = "Welcome";
        }
    }
}
