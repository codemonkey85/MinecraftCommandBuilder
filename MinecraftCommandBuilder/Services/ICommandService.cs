namespace MinecraftCommandBuilder.Services;

public interface ICommandService
{
    string PlayerName { get; set; }

    event Action? OnAppStateChanged;

    void Refresh();

    string CommandText { get; }

    void SetGiveItemCommand(string itemName, int count);

    void SetEnchantCommand(string enchantmentName, int level);

    void SetEffectCommand(string effectName, int duration, int amplifier);

    void SetTeleportCommand(double? x, double? y, double? z);
}
