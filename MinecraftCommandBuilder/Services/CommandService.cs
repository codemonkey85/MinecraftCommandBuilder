namespace MinecraftCommandBuilder.Services;

public class CommandService : ICommandService
{
    public string CommandText { get; private set; } = string.Empty;

    public void SetGiveItemCommand(string playerName, string itemName, int count)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(playerName));
        }

        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be empty.", nameof(itemName));
        }

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0.");
        }

        CommandText = $"/give {playerName} {itemName} {count}";
    }

    public void SetEnchantCommand(string playerName, string enchantmentName, int level)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(playerName));
        }

        if (string.IsNullOrWhiteSpace(enchantmentName))
        {
            throw new ArgumentException("Enchantment name cannot be empty.", nameof(enchantmentName));
        }

        if (level < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(level), "Level must be greater than 0.");
        }

        CommandText = $"/enchant {playerName} {enchantmentName} {level}";
    }

    public void SetEffectCommand(string playerName, string effectName, int duration, int amplifier)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(playerName));
        }

        if (string.IsNullOrWhiteSpace(effectName))
        {
            throw new ArgumentException("Effect name cannot be empty.", nameof(effectName));
        }

        if (duration < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than 0.");
        }

        if (amplifier < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(amplifier), "Amplifier must be greater than 0.");
        }

        CommandText = $"/effect {playerName} {effectName} {duration} {amplifier}";
    }
}
