using PrismLaptopManager.Infrastructure;
using System.Windows.Controls;
using TransactionHistory.ViewModels;

namespace TransactionHistory.Views
{
    /// <summary>
    /// Interaction logic for TransactionHistoryView.xaml
    /// </summary>
    public partial class TransactionHistoryView : UserControl, ITransactionHistoryView
    {
        public TransactionHistoryView(ITransactionHistoryViewModel viewModel)
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
