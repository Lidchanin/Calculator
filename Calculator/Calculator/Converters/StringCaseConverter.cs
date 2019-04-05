using Calculator.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Calculator.Converters
{
    public class StringCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((StringCases)parameter)
            {
                case StringCases.Upper:
                    return value.ToString().ToUpper();
                case StringCases.Lower:
                    return value.ToString().ToLower();
                default:
                    return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}