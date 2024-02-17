namespace MinecraftCommandBuilder.Services;

public interface ICommandService
{
    string PlayerName { get; set; }

    event Action? OnAppStateChanged;

    void Refresh();

    string CommandText { get; set; }

    Task SetGiveItemCommand(string itemName, int count);

    Task SetEnchantCommand(string enchantmentName, int level);

    Task SetEffectCommand(string effectName, int duration, int amplifier, bool clear = false);

    Task SetTeleportCommand(double? x, double? y, double? z);

    Task SetClearAllEffectsCommand();

    Task SetFillCommand(double x1, double y1, double z1, double x2, double y2, double z2, string blockName);

    Task SetFillCommand(string x1, string y1, string z1, string x2, string y2, string z2, string blockName);

    Task SetSummonCommand(string entityName);
}
