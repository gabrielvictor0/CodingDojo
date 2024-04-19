using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using WebApiSpeak.Domains;
using WebApiSpeak.Interface;
using WebApiSpeak.Repository;

namespace WebApiSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakController : ControllerBase
    {
        

        private readonly ISpeak _iSpeak;

        public SpeakController()
        {
            _iSpeak = new SpeakRepository();
        }


        [HttpPost]
        public async Task<IActionResult> SpeechText([FromForm] SpeakDomain audio)
        {
            if (audio != null)
            {
       
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/audios");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var fileName = Guid.NewGuid().ToString() + ".wav";

                var path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    audio.Audio.CopyTo(stream);
                }

                var speechKey = "9d1b809846f5428e93c3a3d12500d8a0";

                var speechRegion = "brazilsouth";

                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                speechConfig.SpeechRecognitionLanguage = "pt-BR";

                using var audioFile = AudioConfig.FromWavFileOutput(path);

                using var speachRecognizer = new SpeechRecognizer(speechConfig, audioFile);

                var speechRecognitionResult = await speachRecognizer.RecognizeOnceAsync();

                //_iSpeak.OuputSpeechRecognitionResult(speechRecognitionResult);
                return Ok( speechRecognitionResult );
            }

            return BadRequest();

            
          
            
        }
    }
}
