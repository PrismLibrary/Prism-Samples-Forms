using System;
using System.Globalization;
using Prism.Modularity;
using Xamarin.Forms;

namespace PrismFormsGallery
{
    public class LoadTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ModuleState)value == ModuleState.Initialized
                ? $"\u2713 {value}"
                : "Tap to initialize";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
