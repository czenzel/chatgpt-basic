using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.OpenAI
{
    public class CompletionRequestModel
    {
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; } = "text-davinci-003";

        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "temperature")]
        public int Temperature { get; set; } = 1;

        [JsonProperty(PropertyName = "max_tokens")]
        public int MaxTokens { get; set; } = 256;

        [JsonProperty(PropertyName = "top_p")]
        public int TopP { get; set; } = 1;

        [JsonProperty(PropertyName = "frequency_penalty")]
        public int FrequencyPenalty = 0;

        [JsonProperty(PropertyName = "presence_penalty")]
        public int PresencePenalty = 0;
    }
}
