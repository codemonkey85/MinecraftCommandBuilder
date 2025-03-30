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
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var appServices = serviceScope.ServiceProvider;

    var pathResolver = appServices.GetRequiredService<DataPathResolver>();
    await pathResolver.Initialize();
}

await app.RunAsync();
