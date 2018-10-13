using System.Threading.Tasks;

namespace UsingPlatformSpecificServices.Services
{
    public interface ITextToSpeech
    {
        Task Speak(string text);
    }
}
