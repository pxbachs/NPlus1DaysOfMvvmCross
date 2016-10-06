using System;
using System.Globalization;
using CollectABull.Core.Services.DataStore;
using MvvmCross.Platform.Converters;

namespace CollectABull.Core.Converters
{
    public class ItemLocationValueConverter
        : MvxValueConverter<CollectedItem>
    {
        protected override object Convert(CollectedItem value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.LocationKnown)
                return "unknown";

            return string.Format("({0:0.0000}, {1:0.0000})", value.Lat, value.Lng);
        }
    }
}