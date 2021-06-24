using System;
using System.Globalization;
using Prism.Logging;
using Xamarin.Forms;

namespace ContosoCookbook.Converters
{
    public class LocalImagePathConverter : IValueConverter
    {
        private static string _assembly;

        static LocalImagePathConverter()
        {
            // Store assembly name (e.g. "ContosoCookbook") with a trailing period
            _assembly = typeof(LocalImagePathConverter).AssemblyQualifiedName.Split(',')[1].Trim() + '.';
        }

        private readonly ILogger _logger;

        public LocalImagePathConverter(ILogger logger)
        {
            _logger = logger;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert an image-path string (e.g. "images/chinese/photo.jpg" into a resource ID
            // (e.g. "ContosoCookbook.images.chinese.photo.jpg") and return an ImageSource
            // wrapping that resource
            string source = _assembly + ((string)value).Replace('/', '.');
            _logger.Debug($"Getting image '{source}'");
            return ImageSource.FromResource(source);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
