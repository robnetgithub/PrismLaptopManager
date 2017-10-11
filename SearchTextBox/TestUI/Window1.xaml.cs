using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIControls;
namespace TestUI {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Supply the control with the list of sections
            List<string> sections = new List<string> { "Hostname", "Model", "Billed User", "Primary User", "Serial #" };
            m_txtTest.SectionsList = sections;

            // Choose a style for displaying sections
            m_txtTest.SectionsStyle = SearchTextBox.SectionsStyles.CheckBoxStyle;

            // Add a routine handling the event OnSearch
            m_txtTest.OnSearch += new RoutedEventHandler(m_txtTest_OnSearch);
        }

        void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;
            
            // Display search data
            string sections = "\r\nSections(s): ";
            foreach (string section in searchArgs.Sections)
                sections += (section + "; ");
            m_txtSearchContent.Text = "Keyword: " + searchArgs.Keyword + sections;
        }
    }

}
