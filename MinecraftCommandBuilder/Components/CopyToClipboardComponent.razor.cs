namespace MinecraftCommandBuilder.Components;

[SupportedOSPlatform("browser")]
public partial class CopyToClipboardComponent : IAsyncDisposable
{
    [Parameter, EditorRequired]
    public string CommandText { get; set; } = string.Empty;

    private bool isJsInitialized = false;

    private IJSObjectReference? module;
    private const string ModuleName = $"{nameof(CopyToClipboardComponent)}.razor.js";
    private const string FullModulePath = $"../{nameof(Components)}/{ModuleName}";

    [JSImport(nameof(CopyTextToClipboard), ModuleName)]
    public static partial void CopyTextToClipboard(string text);

    protected override async Task OnInitializedAsync() =>
        await InitializeJs();

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }

    private async Task InitializeJs()
    {
        if (!OperatingSystem.IsBrowser() || isJsInitialized)
        {
            return;
        }

        await JSHost.ImportAsync(ModuleName, FullModulePath);

        module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", FullModulePath);

        isJsInitialized = true;
    }

    private void CopyCommandText() => CopyTextToClipboard(CommandText);
}
