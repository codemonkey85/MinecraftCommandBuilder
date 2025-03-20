namespace MinecraftCommandBuilder.Pages;

public partial class Home : IDisposable
{
    public void Dispose() => CommandService.OnAppStateChanged -= StateHasChanged;
    protected override void OnInitialized() => CommandService.OnAppStateChanged += StateHasChanged;

    private void ChangeVersion(string newVersion) => MinecraftDataManager.SetVersion(newVersion);
}
