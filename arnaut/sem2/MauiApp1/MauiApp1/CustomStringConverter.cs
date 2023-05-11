using System.Globalization;

namespace MauiApp1;

public class CustomStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((CustomString)value).Value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return new CustomString((string)value);
    }
}