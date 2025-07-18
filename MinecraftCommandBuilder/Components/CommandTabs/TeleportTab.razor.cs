namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class TeleportTab
{
    public const string TabTitle = "Teleport";

    private double? X { get; set; }

    private double? Y { get; set; }

    private double? Z { get; set; }

    private async Task GenerateCommand()
    {
        CommandService.SetTeleportCommand(X, Y, Z);
        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
