using System.Collections;
using System.Collections.Generic;
using Prism.Navigation;

namespace NavigationModule.ViewModels
{
    public class ViewCViewModel : BaseViewModel
    {
        public ViewCViewModel()
        {
            Title = "View C";
        }
        private string _name;
        public string Name { get => _name; set { SetProperty(ref _name, value); } }
    }
}
