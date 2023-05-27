using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.API
{
    public class CompletionResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "completions")]
        public string[]? Completions { get; set; } = new string[] { };
    }
}
