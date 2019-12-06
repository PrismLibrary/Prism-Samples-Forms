using Prism.Mvvm;
using Prism.Services;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IDeviceService _deviceService;

        public string RuntimePlatform { get; set; }
        public string Idiom { get; set; }

        public MainPageViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;

            RuntimePlatform = _deviceService.RuntimePlatform.ToString();
            Idiom = _deviceService.Idiom.ToString();
        }
    }
}