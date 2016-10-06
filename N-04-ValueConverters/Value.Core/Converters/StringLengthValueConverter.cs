using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MvvmCross.Platform.Converters;

namespace Value.Core.Converters
{
    public class StringLengthValueConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value ?? "";
            return value.Length;
        }
    }
}
