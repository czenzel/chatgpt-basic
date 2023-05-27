using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenzel.OpenAI
{
    public static class Configuration
    {
        public const string API_BASE_URI = "https://api.openai.com";
        public const string API_BASE_VERSION = "v1";
        public static string API_KEY { get; set; } = string.Empty;
    }
}
