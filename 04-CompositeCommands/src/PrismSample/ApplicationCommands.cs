using Prism.Commands;

namespace PrismSample
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
        CompositeCommand ResetCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        CompositeCommand _resetCommand = new CompositeCommand();
        public CompositeCommand ResetCommand
        {
            get { return _resetCommand; }
        }
    }
}
