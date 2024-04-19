using Microsoft.CognitiveServices.Speech;

namespace speechservice.Interfaces
{
    public interface ITextRepository
    {
        public string OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text);
    }
}
