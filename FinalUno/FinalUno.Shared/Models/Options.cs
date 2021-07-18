using Newtonsoft.Json;

namespace FinalUno.Models
{
    class Options
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
