namespace MinecraftCommandBuilder.Pages;

public partial class Home : IDisposable
{
    private string Edition => MinecraftDataManager.Edition;

    private string Version => MinecraftDataManager.Version;

    public void Dispose() => CommandService.OnAppStateChanged -= StateHasChanged;

    protected override void OnInitialized() => CommandService.OnAppStateChanged += StateHasChanged;

    private void SetEdition(string edition) => MinecraftDataManager.SetEdition(edition);

    private void SetVersion(string version) => MinecraftDataManager.SetVersion(version);
}
