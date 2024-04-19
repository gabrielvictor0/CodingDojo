using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using speechservice.Interfaces;
using System.IO;
using WebApiSpeak.Interface;
using WebApiSpeak.Repository;

namespace WebApiSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ITextRepository _text;

        public TextController()
        {
                _text = new TextRepository();
        }


        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Text([FromBody] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text cannot be empty");
            }

            var speechKey = "9d1b809846f5428e93c3a3d12500d8a0";
            var speechRegion = "brazilsouth";

            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

            //speechConfig.SpeechSynthesisVoiceName = "pt-BR";

            var fileName = Guid.NewGuid().ToString() + ".wav";

            var folder = Path.Combine("wwwroot/audios", fileName);

            var audioFile = AudioConfig.FromWavFileOutput(folder);

            //SpeechSynthesisCancellationDetails cancellation = null;

            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig, audioFile))
            {
                await speechSynthesizer.SpeakTextAsync(text);
            }

            return Ok(folder);
        }

    }
}
