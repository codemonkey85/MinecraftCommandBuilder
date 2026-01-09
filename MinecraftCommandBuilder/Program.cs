var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

services
    .AddMudServices()
    // Used by MinecraftDataCSharp to read data from the Minecraft data files
    .AddSingleton<DataPathResolver>() // Singleton (shared across the app)
    .AddScoped<MinecraftDataManager>() // Scoped (per request or session)
    .AddScoped<IFileApi, WebFileApi>()
    .AddScoped<BlockRepository>()
    .AddScoped<EffectRepository>()
    .AddScoped<ItemRepository>()
    .AddScoped<BiomeRepository>()
    .AddScoped<EntityRepository>()
    .AddScoped<EnchantmentRepository>()
    .AddScoped<ICommandService, CommandService>()
    // Used by WebFileApi
    .AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#if DEBUG

var aiConfig = builder.Configuration.GetSection(nameof(AiConfig)).Get<AiConfig>() ?? new AiConfig();

var innerChatClient = new AzureOpenAIClient(
        new Uri(aiConfig.Endpoint),
        new ApiKeyCredential(aiConfig.Key))
    .GetChatClient("gpt-5").AsIChatClient();

services.AddChatClient(innerChatClient);

#endif

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var appServices = serviceScope.ServiceProvider;

    var pathResolver = appServices.GetRequiredService<DataPathResolver>();
    await pathResolver.Initialize();
}

await app.RunAsync();
