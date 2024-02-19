namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EnchantsTab
{
    private List<Enchantment> Enchantments { get; set; } = [];

    private Enchantment? SelectedEnchantment { get; set; }

    private int Level { get; set; } = 1;

    private List<string> BestPickaxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune",
    ];

    private List<Enchantment> BestPickaxeEnchantments = [];

    private List<string> BestSwordEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "looting",
        "fire_aspect",
    ];

    private List<Enchantment> BestSwordEnchantments = [];

    private List<string> BestAxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "efficiency",
        "silk_touch",
    ];

    private List<Enchantment> BestAxeEnchantments = [];

    private List<string> BestShovelEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "silk_touch",
    ];

    private List<Enchantment> BestShovelEnchantments = [];

    private List<string> BestHoeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune",
    ];

    private List<Enchantment> BestHoeEnchantments = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Enchantments is [])
        {
            Enchantments = await EnchantmentRepository.GetAllEnchantments() ?? [];
        }

        if (BestPickaxeEnchantments is [])
        {
            foreach (var eName in BestPickaxeEnchantmentNames)
            {
                BestPickaxeEnchantments.Add(Enchantments.First(e => e.name == eName));
            }
        }

        if (BestSwordEnchantments is [])
        {
            foreach (var eName in BestSwordEnchantmentNames)
            {
                BestSwordEnchantments.Add(Enchantments.First(e => e.name == eName));
            }
        }

        if (BestAxeEnchantments is [])
        {
            foreach (var eName in BestAxeEnchantmentNames)
            {
                BestAxeEnchantments.Add(Enchantments.First(e => e.name == eName));
            }
        }

        if (BestShovelEnchantments is [])
        {
            foreach (var eName in BestShovelEnchantmentNames)
            {
                BestShovelEnchantments.Add(Enchantments.First(e => e.name == eName));
            }
        }

        if (BestHoeEnchantments is [])
        {
            foreach (var eName in BestHoeEnchantmentNames)
            {
                BestHoeEnchantments.Add(Enchantments.First(e => e.name == eName));
            }
        }

        foreach (var enchantment in BestPickaxeEnchantments.OrderBy(e => e.name))
        {
            Console.WriteLine(enchantment.name);
        }
    }

    private string GenerateBestEnchantCommand(Enchantment enchantment) =>
        CommandService.GenerateEnchantCommand(
            enchantment.name,
            enchantment.maxLevel);

    private async Task<IEnumerable<Enchantment>> Search(string value)
    {
        await Task.Yield();

        return string.IsNullOrEmpty(value)
            ? Enchantments
            .OrderBy(i => i.displayName)
            .Take(10)

            : (IEnumerable<Enchantment>)Enchantments
                .Where(enchantment => enchantment.displayName
                    .StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.displayName);
    }

    private static string ToString(Enchantment? enchantment) =>
        enchantment?.displayName ?? string.Empty;

    private bool GenerateCommandDisabled => SelectedEnchantment is null;

    private async Task CopyCommand(string command) =>
        await CommandService.CopyTextToClipboard(command);

    private async Task GenerateCommand()
    {
        if (SelectedEnchantment is null)
        {
            return;
        }

        CommandService.SetEnchantCommand(
            SelectedEnchantment.name,
            Level);

        await CopyCommand(CommandService.CommandText);
    }
}
