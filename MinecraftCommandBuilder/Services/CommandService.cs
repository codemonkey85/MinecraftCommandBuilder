namespace MinecraftCommandBuilder.Services;

public class CommandService(IJSRuntime JSRuntime) : ICommandService
{
    public string PlayerName { get; set; } = "@s";

    public event Action? OnAppStateChanged;

    public void Refresh() => OnAppStateChanged?.Invoke();

    public string CommandText { get; set; } = string.Empty;

    private IJSObjectReference? module;

    private async Task CopyTextToClipboard(string text)
    {
        if (!OperatingSystem.IsBrowser())
        {
            return;
        }

        module ??= await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/app.js");
        await module.InvokeVoidAsync(nameof(CopyTextToClipboard), text);
    }

    public async Task SetGiveItemCommand(string itemName, int count)
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

        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetEnchantCommand(string enchantmentName, int level)
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
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetEffectCommand(string effectName, int duration, int amplifier, bool clear = false)
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
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetClearAllEffectsCommand()
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        CommandText = $"/effect clear {PlayerName}";
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetTeleportCommand(double? x, double? y, double? z)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        CommandText = $"/tp {PlayerName} {(x is not null ? x : "~")} {(y is not null ? y : "~")} {(z is not null ? z : "~")}";
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetFillCommand(
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
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetFillCommand(
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
        await CopyTextToClipboard(CommandText);
        Refresh();
    }

    public async Task SetSummonCommand(string entityName)
    {
        if (string.IsNullOrWhiteSpace(entityName))
        {
            throw new ArgumentException("Entity name cannot be empty.", nameof(entityName));
        }

        CommandText = $"/summon {entityName}";
        await CopyTextToClipboard(CommandText);
        Refresh();
    }
}
