using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiSpeak.Domains
{
    public class SpeakDomain
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? Audio { get; set; }
    }
}
