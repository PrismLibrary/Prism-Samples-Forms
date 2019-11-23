using System;
using System.Globalization;
using Prism.Modularity;
using Xamarin.Forms;

namespace PrismFormsGallery
{
    public class StateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ModuleState)value == ModuleState.Initialized
                ? (Color)Application.Current.Resources["PrismBlue"]
                : (Color)Application.Current.Resources["PrismGray"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
