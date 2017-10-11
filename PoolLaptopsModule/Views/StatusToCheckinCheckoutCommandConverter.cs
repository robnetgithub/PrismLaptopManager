using System;
using System.Windows.Data;

namespace PoolLaptops.Views
{
    public class StatusToCheckinCheckoutCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                switch (value.ToString())
                {
                    case "Checked Out": 
                    case "Check In": return "CheckIn";
                    case "Checked In":
                    case "Check Out": return "CheckOut";
                    default: return "CheckLaptop";
                }
            }
            else return "CheckLaptop";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
