using System.Threading.Tasks;

namespace PrismSample.Services
{
    public interface ITextToSpeech
    {
        Task Speak(string text);
    }
}
