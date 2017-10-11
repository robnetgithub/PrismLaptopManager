using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using UIControls;

namespace Toolbar.Views
{
    /// <summary>
    /// Interaction logic for SearchBoxView.xaml
    /// </summary>
    public partial class SearchBoxView : UserControl
    {
        public SearchBoxView()
        {
            InitializeComponent();

            // Supply the control with the list of sections
            List<string> sections = new List<string> { "Hostname", "Model", "Billed User", "Primary User", "Serial #" };
            txtSearchBox.SectionsList = sections;

            // Choose a style for displaying sections
            txtSearchBox.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;

            // Add a routine handling the event OnSearch
            txtSearchBox.OnSearch += new RoutedEventHandler(txtSearchBox_OnSearch);
        }

        void txtSearchBox_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;
            
            // Display search data
            string sections = "\r\nSections(s): ";
            foreach (string section in searchArgs.Sections)
                sections += (section + "; ");
            //m_txtSearchContent.Text = "Keyword: " + searchArgs.Keyword + sections;
        }
    }
}

