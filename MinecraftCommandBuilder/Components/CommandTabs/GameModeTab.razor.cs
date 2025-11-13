namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GameModeTab
{
    public enum GameMode
    {
        Survival,
        Creative,
        Adventure,
        Spectator
    }

    public const string TabTitle = "Game Mode";

    private GameMode SelectedGameMode { get; } = GameMode.Survival;

    private async Task CopyCommand(string command) =>
        await CommandService.CopyTextToClipboard(command);

    private async Task GenerateCommand()
    {
        CommandService.SetSetGameModeCommand(SelectedGameMode);
        await CopyCommand(CommandService.CommandText);
    }
}
