namespace MinecraftCommandBuilder.Services;

public interface ICommandService
{
    string PlayerName { get; set; }

    event Action? OnAppStateChanged;

    void Refresh();

    string CommandText { get; }

    void SetGiveItemCommand(string itemName, int count);

    void SetEnchantCommand(string enchantmentName, int level);

    void SetEffectCommand(string effectName, int duration, int amplifier, bool clear = false);

    void SetTeleportCommand(double? x, double? y, double? z);

    void ClearAllEffectsCommand();

    void SetFillCommand(double x1, double y1, double z1, double x2, double y2, double z2, string blockName);

    void SetFillCommand(string x1, string y1, string z1, string x2, string y2, string z2, string blockName);
}
