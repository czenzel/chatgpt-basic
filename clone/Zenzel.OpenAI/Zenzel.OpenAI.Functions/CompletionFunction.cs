using System.Net;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Zenzel.OpenAI;
using Zenzel.OpenAI.Core.Models.API;
using Zenzel.OpenAI.Core.Models.OpenAI;

namespace Zenzel.OpenAI.Functions
{
    public class CompletionFunction
    {
        private readonly ILogger _logger;
        private readonly CompletionsService _completionsService;

        public CompletionFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CompletionFunction>();
            _completionsService = new CompletionsService();
        }

        [Function("UserInterface")]
        public HttpResponseData UserInterface([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            StreamReader sr = new StreamReader(typeof(CompletionFunction).Assembly!.GetManifestResourceStream("Zenzel.OpenAI.Functions.userinterface.html")!);
            string htmlContents = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();

            var response = req.CreateResponse(HttpStatusCode.InternalServerError);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString($"{htmlContents}");
            return response;
        }

        [Function("TextCompletion")]
        public HttpResponseData TextCompletion([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            HttpResponseData? response = null;

            try
            {
                string userRequestBody = string.Empty;

                using (StreamReader sr = new StreamReader(req.Body))
                {
                    userRequestBody = sr.ReadToEnd();
                }

                CompletionRequest? userRequest = JsonConvert.DeserializeObject<CompletionRequest>(userRequestBody);

                CompletionRequestModel openAiRequest = new CompletionRequestModel()
                {
                    Prompt = userRequest!.Prompt
                };

                CompletionResponseModel? openAiResponse = _completionsService.GetResponses(openAiRequest);

                CompletionResponse userResponse = new CompletionResponse()
                {
                    Completions = openAiResponse!.Choices!.Select(a => a.Text.TrimStart("\n\n".ToCharArray())).ToArray()
                };

                string userResponseBody = JsonConvert.SerializeObject(userResponse);

                response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                response.WriteString(userResponseBody);
            }
            catch (Exception ex)
            {
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                response.WriteString($"Internal Server Error {ex.Message}");
            }

            return response;
        }
    }
}
