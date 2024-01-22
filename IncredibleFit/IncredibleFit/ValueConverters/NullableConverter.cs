// Written by Lasse Foster https://github.com/LaFoster00

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.ValueConverters
{
    public class NullableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string stringValue && (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue)))
            {
                return null;
            }
            return value;
        }
    }
}
