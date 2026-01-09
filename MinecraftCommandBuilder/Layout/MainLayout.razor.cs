namespace MinecraftCommandBuilder.Layout;

public partial class MainLayout
{
    private const string AppTitle = "Minecraft Command Builder";

    private bool IsDarkMode;
    private MudThemeProvider? MudThemeProvider;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && MudThemeProvider is not null)
        {
            IsDarkMode = await MudThemeProvider.GetSystemDarkModeAsync();
            await MudThemeProvider.WatchSystemDarkModeAsync(OnSystemPreferenceChanged);
            StateHasChanged();
        }
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private async Task OnSystemPreferenceChanged(bool newValue)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        IsDarkMode = newValue;
        StateHasChanged();
    }
}
