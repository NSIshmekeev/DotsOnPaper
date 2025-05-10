using System;
using System.Data;
using System.Globalization;
using System.Windows.Data;


namespace DotsOnPaper.Converters
{
    public class CenterShiftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 12;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
