using System.Text.Json.Serialization;

namespace Tarea1ApiPublica.Entities
{
    public class CardResponse
    {
        [JsonPropertyName("cards")]
        public List<Carta> Cartas { get; set; }
    }
}
