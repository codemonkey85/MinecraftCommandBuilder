namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EnchantsTab
{
    private List<Enchantment> Enchantments { get; set; } = [];

    private List<Item> Items { get; set; } = [];

    private Enchantment? SelectedEnchantment { get; set; }

    private int Level { get; set; } = 1;

    private int BestEnchantsLevel { get; set; } = 1;

    private readonly List<string> BestPickaxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune",
    ];

    private readonly List<Enchantment> BestPickaxeEnchantments = [];

    private readonly List<string> BestSwordEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "looting",
        "fire_aspect",
    ];

    private readonly List<Enchantment> BestSwordEnchantments = [];

    private readonly List<string> BestAxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "efficiency",
        "silk_touch",
    ];

    private readonly List<Enchantment> BestAxeEnchantments = [];

    private readonly List<string> BestShovelEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "silk_touch",
    ];

    private readonly List<Enchantment> BestShovelEnchantments = [];

    private readonly List<string> BestHoeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune",
    ];

    private readonly List<Enchantment> BestHoeEnchantments = [];

    private readonly List<string> BestBowEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "power",
        "flame",
    ];

    private readonly List<Enchantment> BestBowEnchantments = [];

    private readonly List<string> BestCrossbowEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "quick_charge",
        "piercing",
    ];

    private readonly List<Enchantment> BestCrossbowEnchantments = [];

    private readonly List<string> BestTridentEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "impaling",
        "loyalty",
        "channeling",
    ];

    private readonly List<Enchantment> BestTridentEnchantments = [];

    private readonly List<string> BestHelmetEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "respiration",
        "aqua_affinity",
        "thorns",
    ];

    private readonly List<Enchantment> BestHelmetEnchantments = [];

    private readonly List<string> BestBodyArmorEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns",
    ];

    private readonly List<Enchantment> BestBodyArmorEnchantments = [];

    private readonly List<string> BestLeggingsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns",
        "swift_sneak",
    ];

    private readonly List<Enchantment> BestLeggingsEnchantments = [];

    private readonly List<string> BestBootsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns",
        "feather_falling",
        "depth_strider",
        "soul_speed",
    ];

    private readonly List<Enchantment> BestBootsEnchantments = [];

    private readonly List<string> BestElytraEnchantmentNames =
    [
        "unbreaking",
        "mending",
    ];

    private readonly List<Enchantment> BestElytraEnchantments = [];

    private readonly List<string> BestShieldEnchantmentNames =
    [
        "unbreaking",
        "mending",
    ];

    private readonly List<Enchantment> BestShieldEnchantments = [];

    private readonly List<string> BestShearsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
    ];

    private readonly List<Enchantment> BestShearsEnchantments = [];

    private readonly List<string> BestFlintAndSteelEnchantmentNames =
    [
        "unbreaking",
        "mending",
    ];

    private readonly List<Enchantment> BestFlintAndSteelEnchantments = [];

    private readonly List<string> BestBrushEnchantmentNames =
    [
        "unbreaking",
        "mending",
    ];

    private readonly List<Enchantment> BestBrushEnchantments = [];

    private readonly List<string> BestTurtleShellEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "respiration",
        "aqua_affinity",
    ];

    private readonly List<Enchantment> BestTurtleShellEnchantments = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await InitializeEnchantments();
        if (Items is [])
        {
            Items = await ItemRepository.GetAllItems() ?? [];
        }
    }

    private async Task InitializeEnchantments()
    {
        if (Enchantments is [])
        {
            Enchantments = await EnchantmentRepository.GetAllEnchantments() ?? [];
        }

        if (BestPickaxeEnchantments is [])
        {
            foreach (var eName in BestPickaxeEnchantmentNames)
            {
                BestPickaxeEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestSwordEnchantments is [])
        {
            foreach (var eName in BestSwordEnchantmentNames)
            {
                BestSwordEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestAxeEnchantments is [])
        {
            foreach (var eName in BestAxeEnchantmentNames)
            {
                BestAxeEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestShovelEnchantments is [])
        {
            foreach (var eName in BestShovelEnchantmentNames)
            {
                BestShovelEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestHoeEnchantments is [])
        {
            foreach (var eName in BestHoeEnchantmentNames)
            {
                BestHoeEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestBowEnchantments is [])
        {
            foreach (var eName in BestBowEnchantmentNames)
            {
                BestBowEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestCrossbowEnchantments is [])
        {
            foreach (var eName in BestCrossbowEnchantmentNames)
            {
                BestCrossbowEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestTridentEnchantments is [])
        {
            foreach (var eName in BestTridentEnchantmentNames)
            {
                BestTridentEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestHelmetEnchantments is [])
        {
            foreach (var eName in BestHelmetEnchantmentNames)
            {
                BestHelmetEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestBodyArmorEnchantments is [])
        {
            foreach (var eName in BestBodyArmorEnchantmentNames)
            {
                BestBodyArmorEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestLeggingsEnchantments is [])
        {
            foreach (var eName in BestLeggingsEnchantmentNames)
            {
                BestLeggingsEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestBootsEnchantments is [])
        {
            foreach (var eName in BestBootsEnchantmentNames)
            {
                BestBootsEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestElytraEnchantments is [])
        {
            foreach (var eName in BestElytraEnchantmentNames)
            {
                BestElytraEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestShieldEnchantments is [])
        {
            foreach (var eName in BestShieldEnchantmentNames)
            {
                BestShieldEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestShearsEnchantments is [])
        {
            foreach (var eName in BestShearsEnchantmentNames)
            {
                BestShearsEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestFlintAndSteelEnchantments is [])
        {
            foreach (var eName in BestFlintAndSteelEnchantmentNames)
            {
                BestFlintAndSteelEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestBrushEnchantments is [])
        {
            foreach (var eName in BestBrushEnchantmentNames)
            {
                BestBrushEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }

        if (BestTurtleShellEnchantments is [])
        {
            foreach (var eName in BestTurtleShellEnchantmentNames)
            {
                BestTurtleShellEnchantments.Add(Enchantments.First(e => e.Name == eName));
            }
        }
    }

    private string GenerateBestEnchantCommand(Enchantment enchantment) =>
        CommandService.GenerateEnchantCommand(
            enchantment.Name,
            enchantment.MaxLevel);

    private async Task<IEnumerable<Enchantment>> Search(string value, CancellationToken cancellationToken)
    {
        await Task.Yield();

        return string.IsNullOrEmpty(value)
            ? Enchantments
            .OrderBy(i => i.DisplayName)
            .Take(10)

            : (IEnumerable<Enchantment>)Enchantments
                .Where(enchantment => enchantment.DisplayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.DisplayName);
    }

    private Item? GetItem(string itemName)
    {
        return string.IsNullOrEmpty(itemName)
            ? null
            : Items
                .FirstOrDefault(item => item.DisplayName
                .Equals(itemName.Trim(), StringComparison.InvariantCultureIgnoreCase));
    }

    private string GenerateGiveEnchantedItemCommand(string itemName, List<Enchantment> enchantments, int level) =>
        CommandService.GenerateGiveEnchantedItemCommand(
            itemName,
            enchantments
                .Select(e => new EnchantmentModel
                {
                    Name = e.Name,
                    Level = level,
                }).ToList());

    private static string ToString(Enchantment? enchantment) =>
        enchantment?.DisplayName ?? string.Empty;

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
            SelectedEnchantment.Name,
            Level);

        await CopyCommand(CommandService.CommandText);
    }
}
