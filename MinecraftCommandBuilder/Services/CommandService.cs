using static MinecraftCommandBuilder.Components.CommandTabs.GameModeTab;

namespace MinecraftCommandBuilder.Services;

public class CommandService(IJSRuntime jsRuntime) : ICommandService
{
    // ReSharper disable once InconsistentNaming
    private IJSObjectReference? module;
    private IJSRuntime JsRuntime { get; } = jsRuntime;

    public string PlayerName { get; set; } = "@s";

    public event Action? OnAppStateChanged;

    public void Refresh() => OnAppStateChanged?.Invoke();

    public string CommandText { get; set; } = string.Empty;

    public async Task CopyTextToClipboard(string text)
    {
        if (!OperatingSystem.IsBrowser())
        {
            return;
        }

        module ??= await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/app.js");
        await module.InvokeVoidAsync(nameof(CopyTextToClipboard), text);
    }

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

    public string GenerateGiveEnchantedItemCommand(string itemName, List<EnchantmentModel> enchantments)
    {
        var enchantmentsString = string.Empty;
        if (enchantments is { Count: > 0 })
        {
            var sbEnchantments = new StringBuilder();
            sbEnchantments.Append('{');
            foreach (var enchantment in enchantments)
            {
                sbEnchantments.Append($"{enchantment.Name}:{enchantment.Level},");
            }

            sbEnchantments.Length--;
            sbEnchantments.Append('}');
            enchantmentsString = $"[minecraft:enchantments={sbEnchantments}]";
        }

        return $"/give {PlayerName} {itemName}{enchantmentsString}";
    }

    public string GenerateEnchantCommand(string enchantmentName, int level)
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

        return $"/enchant {PlayerName} {enchantmentName} {level}";
    }

    public void SetEnchantCommand(string enchantmentName, int level)
    {
        CommandText = GenerateEnchantCommand(enchantmentName, level);
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

        if (!clear && duration < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than 0.");
        }

        if (!clear && amplifier < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(amplifier), "Amplifier must be greater than 0.");
        }

        CommandText = $"/effect {PlayerName} {effectName}{(clear ? " 0" : $" {duration}")}{(clear ? string.Empty : $" {amplifier}")}";
        Refresh();
    }

    public void SetClearAllEffectsCommand()
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

    public void SetSummonCommand(string entityName)
    {
        if (string.IsNullOrWhiteSpace(entityName))
        {
            throw new ArgumentException("Entity name cannot be empty.", nameof(entityName));
        }

        CommandText = $"/summon {entityName}";
        Refresh();
    }

    public void SetSetGameModeCommand(GameMode gameMode)
    {
        if (string.IsNullOrWhiteSpace(PlayerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(PlayerName));
        }

        CommandText = $"/gamemode {gameMode} {PlayerName}";
        Refresh();
    }
}
