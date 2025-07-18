namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GameModeTab
{
    public const string TabTitle = "Game Mode";

    public enum GameMode
    {
        Survival,
        Creative,
        Adventure,
        Spectator
    }

    private GameMode SelectedGameMode { get; set; } = GameMode.Survival;

    private async Task CopyCommand(string command) =>
        await CommandService.CopyTextToClipboard(command);

    private async Task GenerateCommand()
    {
        CommandService.SetSetGameModeCommand(SelectedGameMode);
        await CopyCommand(CommandService.CommandText);
    }
}
