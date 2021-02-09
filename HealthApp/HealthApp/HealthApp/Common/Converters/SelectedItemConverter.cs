using System;
using System.Globalization;
using Xamarin.Forms;

namespace HealthApp.Common.Converters
{
    public class SelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                if ((bool)value)
                    return 1;
                else return 0.2;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
