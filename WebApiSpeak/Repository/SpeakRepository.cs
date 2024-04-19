using Microsoft.CognitiveServices.Speech;
using WebApiSpeak.Interface;

namespace WebApiSpeak.Repository
{
    public class SpeakRepository : ISpeak
    {
        public string OuputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult, IFormFile audio)
        {
           
            
            switch (speechRecognitionResult.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    return ($"Recognized: TEXT={speechRecognitionResult.Text}");
                case ResultReason.NoMatch:
                    return ($"NOmatch: nao pode ser reconhecido");
                case ResultReason.Canceled: 
                    var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                    return ($"CANCELLED: Reason={cancellation.Reason}");
                default:
                    return ("Error");
            }
        }

        
    }
}
