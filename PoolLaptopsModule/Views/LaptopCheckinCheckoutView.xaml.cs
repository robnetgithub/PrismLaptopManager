using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismLaptopManager.Infrastructure;
using PoolLaptops.ViewModels;

namespace PoolLaptops.Views
{
    /// <summary>
    /// Interaction logic for LaptopCheckinCheckoutView.xaml
    /// </summary>
    public partial class LaptopCheckinCheckoutView : UserControl, ILaptopCheckinCheckoutView
    {
        public LaptopCheckinCheckoutView(ILaptopCheckinCheckoutViewModel viewModel)
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
