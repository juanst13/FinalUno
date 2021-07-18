using Newtonsoft.Json;


namespace FinalUno.Models
{
    class QuestionResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("options")]
        public Option[] Options { get; set; }
    }
}
