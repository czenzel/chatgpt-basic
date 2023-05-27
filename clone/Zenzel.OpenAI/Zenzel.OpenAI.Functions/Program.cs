using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(config =>
    {
        config.AddUserSecrets<Program>(optional: true, reloadOnChange: true);
    })
    .ConfigureServices(s =>
    {
        IConfiguration? config = s.BuildServiceProvider().GetService<IConfiguration>();
        string apiKey = config!.GetValue<string>("openAiKey");
        Zenzel.OpenAI.Configuration.API_KEY = apiKey;
    })
    .Build();

host.Run();
