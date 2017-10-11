using System;
using System.Windows.Data;

namespace PoolLaptops.Views
{
    public class StatusToButtonColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                switch (value.ToString())
                {
                    case "Checked Out": case "Check In": return "Red";
                    case "Checked In": case "Check Out": return "Green";
                    default: return "White";
                }
            }
            else return "White";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
