using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.OpenAI
{
    public class ChoicesResponseModel
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }


        [JsonProperty(PropertyName = "logprobs")]
        public string? LogProbs { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "finish_reason")]
        public string FinishReason { get; set; } = string.Empty;
    }
}
