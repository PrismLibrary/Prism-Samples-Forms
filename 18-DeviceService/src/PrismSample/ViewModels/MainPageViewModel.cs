using Prism.AppModel;
using Prism.Mvvm;
using Prism.Services;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IDeviceService _deviceService;

        public TargetIdiom Idiom { get; }
        public RuntimePlatform RuntimePlatform { get; }

        public MainPageViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;

            RuntimePlatform = _deviceService.RuntimePlatform;
            Idiom = _deviceService.Idiom;
        }
    }
}