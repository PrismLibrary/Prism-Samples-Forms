using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class InformationPageViewModel : BindableBase, INavigationAware
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                SetProperty(ref _text, value);
            }
        }

        public InformationPageViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Message"))
            {
                Text = parameters.GetValue<string>("Message");
            }

            if (parameters.ContainsKey("MoreMessages"))
            {
                Text += " " + parameters.GetValue<string>("MoreMessages");
            }
        }
    }
}
