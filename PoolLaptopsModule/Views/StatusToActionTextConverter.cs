using System;
using System.Windows.Data;

namespace PoolLaptops.Views
{
    public class StatusToActionTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                switch (value.ToString())
                {
                    case "Checked Out": return "Check In";

                    case "Checked In": return "Check Out";

                    default: return "Check!";
                }
            }
            else return "Check!";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
