namespace MinecraftCommandBuilder.Pages;

public partial class Home : IDisposable
{
    private string SelectedEdition => MinecraftDataManager.Edition;

    private string SelectedVersion => MinecraftDataManager.Version;

    private static List<string> Editions => [.. MinecraftDataCSharp.Editions.GetAll()];

    private List<string> Versions => SelectedEdition switch
    {
        MinecraftDataCSharp.Editions.Pc => [.. PcVersions.GetAll()],
        MinecraftDataCSharp.Editions.Bedrock => [.. BedrockVersions.GetAll()],
        _ => []
    };

    public void Dispose() => CommandService.OnAppStateChanged -= StateHasChanged;

    protected override void OnInitialized() => CommandService.OnAppStateChanged += StateHasChanged;

    private void SetEdition(string edition) => MinecraftDataManager.SetEdition(edition);

    private void SetVersion(string version) => MinecraftDataManager.SetVersion(version);
}
