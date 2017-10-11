using Prism.Events;
using PrismLaptopManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Statusbar.Views;
using Prism.Regions;
using Microsoft.Practices.Unity;


namespace Statusbar.ViewModels
{
    public class StatusbarViewModel : BindableBase, IStatusbarViewModel
    {
        IRegionManager regionManager;
        IUnityContainer container;
        IEventAggregator eventAggregator;
        private string message = "Ready";

        public string Message 
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public StatusbarViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<LaptopUpdatedEvent>().Subscribe(LaptopUpdated);
        }

        private void LaptopUpdated(string obj)
        {
            Message = obj;
        }
    }
}
