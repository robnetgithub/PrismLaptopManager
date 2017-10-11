using System;
using System.Windows.Controls;

namespace Toolbar.Views
{
    /// <summary>
    /// Interaction logic for ToolbarLoggededOnUserView.xaml
    /// </summary>
    public partial class ToolbarLoggededOnUserView : UserControl
    {
        public ToolbarLoggededOnUserView()
        {
            InitializeComponent();
            loggedOnUserTextBlock.Text = Environment.UserName;
        }
    }
}
