using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.OpenAI
{
    public class UsageResponseModel
    {
        [JsonProperty(PropertyName = "prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonProperty(PropertyName = "completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonProperty(PropertyName = "total_tokens")]
        public int TotalTokens { get; set; }
    }
}
