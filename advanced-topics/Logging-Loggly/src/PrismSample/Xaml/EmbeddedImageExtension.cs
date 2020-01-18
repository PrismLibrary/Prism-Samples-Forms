using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSample.Xaml
{
    [ContentProperty(nameof(Name))]
    public class EmbeddedImageExtension : BindableObject, IMarkupExtension
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(EmbeddedImageExtension), null);

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        Image image;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = serviceProvider.GetService<IProvideValueTarget>();
            image = (Image)provideValueTarget.TargetObject;
            image.BindingContextChanged += Image_BindingContextChanged;
            return null;
        }

        private void Image_BindingContextChanged(object sender, EventArgs e)
        {
            if(image.BindingContext is null)
            {
                image.Source = null;
                image.BindingContextChanged -= Image_BindingContextChanged;
            }
            else
            {
                BindingContext = image.BindingContext;
                image.Source = ImageSource.FromResource(Name, GetType().Assembly);
            }
        }
    }
}
