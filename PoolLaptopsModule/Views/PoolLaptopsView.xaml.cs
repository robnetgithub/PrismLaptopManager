using PoolLaptops.ViewModels;
using PrismLaptopManager.Infrastructure;
using System.Windows.Controls;

namespace PoolLaptops.Views
{
    /// <summary>
    /// Interaction logic for PoolLaptopsView.xaml
    /// </summary>
    public partial class PoolLaptopsView : UserControl, IPoolLaptopsView
    {
        public PoolLaptopsView(IPoolLaptopsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
