using Newtonsoft.Json;

namespace FinalUno.Models
{
    class Option
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
