using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Zenzel.OpenAI.Core.Models.OpenAI;

namespace Zenzel.OpenAI
{
    public class CompletionsService
    {
        private const string API_SUFFIX_URI = $"{Configuration.API_BASE_VERSION}/completions";
        private HttpClient? _httpClient = null;

        public CompletionResponseModel? GetResponses(CompletionRequestModel request)
        {
            TaskCompletionSource<CompletionResponseModel?> tcs = new TaskCompletionSource<CompletionResponseModel?>();

            Task.Run(async () =>
            {
                try
                {
                    string requestPostBody = JsonConvert.SerializeObject(request);
                    HttpResponseMessage responsePost = await HttpClient.PostAsync(API_SUFFIX_URI, new StringContent(requestPostBody, Encoding.UTF8, "application/json"));
                    string responsePostString = await responsePost.Content.ReadAsStringAsync();
                    CompletionResponseModel? response = JsonConvert.DeserializeObject<CompletionResponseModel>(responsePostString);
                    _ = tcs.TrySetResult(response);
                }
                catch (Exception ex)
                {
                    _ = tcs.TrySetException(ex);
                }
            });

            return tcs.Task.GetAwaiter().GetResult();
        }

        private HttpClient HttpClient
        {
            get
            {
                if (_httpClient != null)
                    return _httpClient;

                _httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(Configuration.API_BASE_URI)
                };

                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Configuration.API_KEY}");
                return _httpClient;
            }
        }
    }
}