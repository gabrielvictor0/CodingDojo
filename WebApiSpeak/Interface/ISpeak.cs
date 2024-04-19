using Microsoft.CognitiveServices.Speech;

namespace WebApiSpeak.Interface
{
    public interface ISpeak
    {
        public string OuputSpeechRecognitionResult (SpeechRecognitionResult speechRecognitionResult, IFormFile audio);
    }
}
