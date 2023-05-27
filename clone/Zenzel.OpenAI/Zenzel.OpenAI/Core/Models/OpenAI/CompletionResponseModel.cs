using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenzel.OpenAI.Core.Models.OpenAI
{
    public class CompletionResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "created")]
        public int Created { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "choices")]
        public ChoicesResponseModel[]? Choices { get; set; }

        [JsonProperty(PropertyName = "usage")]
        public UsageResponseModel? Usage { get; set; }

        [JsonIgnore]
        public bool Success => Choices != null ?
            Choices.Length > 0 :
            false;
    }
}
