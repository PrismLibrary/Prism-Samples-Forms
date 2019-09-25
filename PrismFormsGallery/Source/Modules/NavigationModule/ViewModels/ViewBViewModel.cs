using System;
using Prism.AppModel;
using Prism.Navigation;

namespace NavigationModule.ViewModels
{
    public class ViewBViewModel : BaseViewModel, IAutoInitialize
    {
        public ViewBViewModel()
        {
            Title = "View B";
        }

        private string _name;
        public string Name { get => _name; set { SetProperty(ref _name, value); } }
    }
}
