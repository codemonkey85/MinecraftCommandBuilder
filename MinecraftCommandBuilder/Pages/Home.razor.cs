namespace MinecraftCommandBuilder.Pages;

public partial class Home : IDisposable
{
    protected override void OnInitialized() => CommandService.OnAppStateChanged += StateHasChanged;

    public void Dispose() => CommandService.OnAppStateChanged -= StateHasChanged;
}
