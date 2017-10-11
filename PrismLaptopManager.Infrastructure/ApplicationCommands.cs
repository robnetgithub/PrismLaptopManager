using Prism.Commands;

namespace PrismLaptopManager.Infrastructure
{
    public class ApplicationCommands
    {
        public static CompositeCommand NavigateCommand = new CompositeCommand();
        public static CompositeCommand CheckInOutCommand = new CompositeCommand();
    }
}
