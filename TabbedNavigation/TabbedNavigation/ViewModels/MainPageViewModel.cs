using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TabbedNavigation.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            LaunchDynamicTabbedPageCommand = new DelegateCommand(OnLaunchDynamicTabbedPageCommandExecuted);
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _showViewA;
        public bool ShowViewA
        {
            get { return _showViewA; }
            set { SetProperty(ref _showViewA, value); }
        }

        private bool _showViewB;
        public bool ShowViewB
        {
            get { return _showViewB; }
            set { SetProperty(ref _showViewB, value); }
        }

        private bool _showViewC;
        public bool ShowViewC
        {
            get { return _showViewC; }
            set { SetProperty(ref _showViewC, value ); }
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public DelegateCommand LaunchDynamicTabbedPageCommand { get; }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        private void OnNavigateCommandExecuted(string path) =>
            _navigationService.NavigateAsync(path);

        private void OnLaunchDynamicTabbedPageCommandExecuted()
        {
            string path = "DynamicTabbedPage";
            var children = new List<string>();
            if(ShowViewA)
                children.Add("addTab=ViewA");

            if(ShowViewB)
                children.Add("addTab=ViewB");

            if(ShowViewC)
                children.Add("addTab=ViewC");

            if(children.Count > 0)
                path += "?" + string.Join("&", children);

            _navigationService.NavigateAsync(path);
        }
    }
}

