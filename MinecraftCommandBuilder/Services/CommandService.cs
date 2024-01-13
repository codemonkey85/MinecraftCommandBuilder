namespace MinecraftCommandBuilder.Services;

public class CommandService : ICommandService
{
    public string PlayerName { get; set; } = "@s";

    public event Action? OnAppStateChanged;

    public void Refresh() => OnAppStateChanged?.Invoke();

    public string CommandText { get; private set; } = string.Empty;

    public void SetGiveItemCommand(string itemName, int count)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be empty.", nameof(itemName));
        }

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0.");
        }

        CommandText = $"/give {PlayerName} {itemName} {count}";
        Refresh();
    }

    public void SetEnchantCommand(string enchantmentName, int level)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        if (string.IsNullOrWhiteSpace(enchantmentName))
        {
            throw new ArgumentException("Enchantment name cannot be empty.", nameof(enchantmentName));
        }

        if (level < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(level), "Level must be greater than 0.");
        }

        CommandText = $"/enchant {PlayerName} {enchantmentName} {level}";
        Refresh();
    }

    public void SetEffectCommand(string effectName, int duration, int amplifier, bool clear = false)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
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

        CommandText = $"/effect{(clear ? " clear" : "")} {PlayerName} {effectName} {duration} {amplifier}";
        Refresh();
    }

    public void ClearAllEffectsCommand()
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        CommandText = $"/effect clear {PlayerName}";
        Refresh();
    }

    public void SetTeleportCommand(double? x, double? y, double? z)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        CommandText = $"/tp {PlayerName} {(x is not null ? x : "~")} {(y is not null ? y : "~")} {(z is not null ? z : "~")}";
        Refresh();
    }

    public void SetFillCommand(
        double x1,
        double y1,
        double z1,
        double x2,
        double y2,
        double z2,
        string blockName)
    {
        if (string.IsNullOrWhiteSpace(blockName))
        {
            throw new ArgumentException("Block name cannot be empty.", nameof(blockName));
        }

        CommandText = $"/fill {x1} {y1} {z1} {x2} {y2} {z2} {blockName}";
        Refresh();
    }

    public void SetFillCommand(
        string x1,
        string y1,
        string z1,
        string x2,
        string y2,
        string z2,
        string blockName)
    {
        if (string.IsNullOrWhiteSpace(blockName))
        {
            throw new ArgumentException("Block name cannot be empty.", nameof(blockName));
        }

        CommandText = $"/fill {x1} {y1} {z1} {x2} {y2} {z2} {blockName}";
        Refresh();
    }
}
