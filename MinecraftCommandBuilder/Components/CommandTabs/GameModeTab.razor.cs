using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GameModeTab
{
    private GameMode SelectedGameMode { get; set; } = GameMode.Survival;

    private async Task CopyCommand(string command) =>
        await CommandService.CopyTextToClipboard(command);

    private async Task GenerateCommand()
    {
        CommandService.SetSetGameModeCommand(SelectedGameMode);
        await CopyCommand(CommandService.CommandText);
    }

    public enum GameMode
    {
        Survival,
        Creative,
        Adventure,
        Spectator
    }
}
