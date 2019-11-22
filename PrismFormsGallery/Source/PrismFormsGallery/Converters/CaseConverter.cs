using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PrismFormsGallery
{
    public class CaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetFriendlyName(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        string GetFriendlyName(string name)
        {
            var sb = new StringBuilder();
            sb.Append(name[0]);

            for (int i = 1; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]))
                    sb.Append(" ");
                sb.Append(name[i]);
            }
            return sb?.ToString() ?? name;
        }
    }
}
