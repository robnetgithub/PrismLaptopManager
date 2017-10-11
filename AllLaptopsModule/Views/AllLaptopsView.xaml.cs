using AllLaptopsModule.Views;
using PrismLaptopManager.Infrastructure;
using System.Windows.Controls;

namespace AllLaptops.Views
{
    /// <summary>
    /// Interaction logic for AllLaptopsView.xaml
    /// </summary>
    [RibbonTab(typeof(Ribbon))]
    public partial class AllLaptopsView : UserControl
    {
        public AllLaptopsView()
        {
            InitializeComponent();
        }
    }
}
