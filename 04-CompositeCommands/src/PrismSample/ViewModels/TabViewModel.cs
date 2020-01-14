using Prism.Commands;
using Prism.Mvvm;
using System;

namespace PrismSample.ViewModels
{
    public class TabViewModel : BindableBase
    {
        private string _lastSaved;
        public string LastSaved
        {
            get { return _lastSaved; }
            set { SetProperty(ref _lastSaved, value); }
        }

        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        public DelegateCommand ResetCommand => new DelegateCommand(Reset);

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
            applicationCommands.ResetCommand.RegisterCommand(ResetCommand);
        }

        private void Save()
        {
            LastSaved = DateTime.Now.ToString();
        }

        private void Reset()
        {
            LastSaved = "Reset - no value";
        }
    }
}
