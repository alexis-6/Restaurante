using Newtonsoft.Json;

namespace Restaurante.BL.DTOs
{
    public class RespuestaDTO
    {
        [JsonProperty("Code")]
        public int Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Data")]
        public dynamic Data { get; set; }
    }
}
