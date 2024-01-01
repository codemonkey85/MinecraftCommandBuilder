namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class TeleportTab
{
    private double? X { get; set; }

    private double? Y { get; set; }

    private double? Z { get; set; }

    private bool GenerateCommandDisabled => false;

    private void GenerateCommand() =>
        CommandService.SetTeleportCommand(X, Y, Z);
}
