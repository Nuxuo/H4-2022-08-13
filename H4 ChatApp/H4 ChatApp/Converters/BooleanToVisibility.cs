using H4_ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace H4_ChatApp.Converters
{
    public class BooleanToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter as string;
            if (param == "Inverse")
            {
                return !(bool)value;
            }

            return (bool)value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
