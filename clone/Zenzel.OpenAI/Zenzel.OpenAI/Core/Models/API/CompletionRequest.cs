using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.API
{
    public class CompletionRequest
    {
        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; set; } = string.Empty;

        [JsonIgnore]
        public bool Success => !string.IsNullOrWhiteSpace(Prompt);
    }
}
