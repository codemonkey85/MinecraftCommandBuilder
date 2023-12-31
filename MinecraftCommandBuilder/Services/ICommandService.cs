namespace MinecraftCommandBuilder.Services;

public interface ICommandService
{
    string CommandText { get; }

    void SetGiveItemCommand(string playerName, string itemName, int count);

    void SetEnchantCommand(string playerName, string enchantmentName, int level);

    void SetEffectCommand(string playerName, string effectName, int duration, int amplifier);
}
