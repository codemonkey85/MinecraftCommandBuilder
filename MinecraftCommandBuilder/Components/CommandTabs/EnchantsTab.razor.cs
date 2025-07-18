namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EnchantsTab
{
    public const string TabTitle = "Enchantments";

    private readonly List<string> BestAxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "efficiency",
        "silk_touch"
    ];

    private readonly List<Enchantment> BestAxeEnchantments = [];

    private readonly List<string> BestBodyArmorEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns"
    ];

    private readonly List<Enchantment> BestBodyArmorEnchantments = [];

    private readonly List<string> BestBootsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns",
        "feather_falling",
        "depth_strider",
        "soul_speed"
    ];

    private readonly List<Enchantment> BestBootsEnchantments = [];

    private readonly List<string> BestBowEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "power",
        "flame"
    ];

    private readonly List<Enchantment> BestBowEnchantments = [];

    private readonly List<string> BestBrushEnchantmentNames =
    [
        "unbreaking",
        "mending"
    ];

    private readonly List<Enchantment> BestBrushEnchantments = [];

    private readonly List<string> BestCrossbowEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "quick_charge",
        "piercing"
    ];

    private readonly List<Enchantment> BestCrossbowEnchantments = [];

    private readonly List<string> BestElytraEnchantmentNames =
    [
        "unbreaking",
        "mending"
    ];

    private readonly List<Enchantment> BestElytraEnchantments = [];

    private readonly List<string> BestFlintAndSteelEnchantmentNames =
    [
        "unbreaking",
        "mending"
    ];

    private readonly List<Enchantment> BestFlintAndSteelEnchantments = [];

    private readonly List<string> BestHelmetEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "respiration",
        "aqua_affinity",
        "thorns"
    ];

    private readonly List<Enchantment> BestHelmetEnchantments = [];

    private readonly List<string> BestHoeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune"
    ];

    private readonly List<Enchantment> BestHoeEnchantments = [];

    private readonly List<string> BestLeggingsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "thorns",
        "swift_sneak"
    ];

    private readonly List<Enchantment> BestLeggingsEnchantments = [];

    private readonly List<string> BestPickaxeEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "fortune"
    ];

    private readonly List<Enchantment> BestPickaxeEnchantments = [];

    private readonly List<string> BestShearsEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency"
    ];

    private readonly List<Enchantment> BestShearsEnchantments = [];

    private readonly List<string> BestShieldEnchantmentNames =
    [
        "unbreaking",
        "mending"
    ];

    private readonly List<Enchantment> BestShieldEnchantments = [];

    private readonly List<string> BestShovelEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "efficiency",
        "silk_touch"
    ];

    private readonly List<Enchantment> BestShovelEnchantments = [];

    private readonly List<string> BestSwordEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "sharpness",
        "looting",
        "fire_aspect"
    ];

    private readonly List<Enchantment> BestSwordEnchantments = [];

    private readonly List<string> BestTridentEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "impaling",
        "loyalty",
        "channeling"
    ];

    private readonly List<Enchantment> BestTridentEnchantments = [];

    private readonly List<string> BestTurtleShellEnchantmentNames =
    [
        "unbreaking",
        "mending",
        "protection",
        "respiration",
        "aqua_affinity"
    ];

    private readonly List<Enchantment> BestTurtleShellEnchantments = [];

    private List<Enchantment> Enchantments { get; set; } = [];

    private List<Item> Items { get; set; } = [];

    private Enchantment? SelectedEnchantment { get; set; }

    private int Level { get; set; } = 1;

    private int BestEnchantsLevel { get; set; } = 1;

    private bool GenerateCommandDisabled => SelectedEnchantment is null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await InitializeEnchantments();
    }

    private async Task InitializeEnchantments()
    {
        Enchantments = await EnchantmentRepository.GetAllEnchantments();
        Items = await ItemRepository.GetAllItems();

        if (BestPickaxeEnchantments is [])
        {
            foreach (var eName in BestPickaxeEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestPickaxeEnchantments.Add(enchantment);
                }
            }
        }

        if (BestSwordEnchantments is [])
        {
            foreach (var eName in BestSwordEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestSwordEnchantments.Add(enchantment);
                }
            }
        }

        if (BestAxeEnchantments is [])
        {
            foreach (var eName in BestAxeEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestAxeEnchantments.Add(enchantment);
                }
            }
        }

        if (BestShovelEnchantments is [])
        {
            foreach (var eName in BestShovelEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestShovelEnchantments.Add(enchantment);
                }
            }
        }

        if (BestHoeEnchantments is [])
        {
            foreach (var eName in BestHoeEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestHoeEnchantments.Add(enchantment);
                }
            }
        }

        if (BestBowEnchantments is [])
        {
            foreach (var eName in BestBowEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestBowEnchantments.Add(enchantment);
                }
            }
        }

        if (BestCrossbowEnchantments is [])
        {
            foreach (var eName in BestCrossbowEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestCrossbowEnchantments.Add(enchantment);
                }
            }
        }

        if (BestTridentEnchantments is [])
        {
            foreach (var eName in BestTridentEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestTridentEnchantments.Add(enchantment);
                }
            }
        }

        if (BestHelmetEnchantments is [])
        {
            foreach (var eName in BestHelmetEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestHelmetEnchantments.Add(enchantment);
                }
            }
        }

        if (BestBodyArmorEnchantments is [])
        {
            foreach (var eName in BestBodyArmorEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestBodyArmorEnchantments.Add(enchantment);
                }
            }
        }

        if (BestLeggingsEnchantments is [])
        {
            foreach (var eName in BestLeggingsEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestLeggingsEnchantments.Add(enchantment);
                }
            }
        }

        if (BestBootsEnchantments is [])
        {
            foreach (var eName in BestBootsEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestBootsEnchantments.Add(enchantment);
                }
            }
        }

        if (BestElytraEnchantments is [])
        {
            foreach (var eName in BestElytraEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestElytraEnchantments.Add(enchantment);
                }
            }
        }

        if (BestShieldEnchantments is [])
        {
            foreach (var eName in BestShieldEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestShieldEnchantments.Add(enchantment);
                }
            }
        }

        if (BestShearsEnchantments is [])
        {
            foreach (var eName in BestShearsEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestShearsEnchantments.Add(enchantment);
                }
            }
        }

        if (BestFlintAndSteelEnchantments is [])
        {
            foreach (var eName in BestFlintAndSteelEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestFlintAndSteelEnchantments.Add(enchantment);
                }
            }
        }

        if (BestBrushEnchantments is [])
        {
            foreach (var eName in BestBrushEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestBrushEnchantments.Add(enchantment);
                }
            }
        }

        if (BestTurtleShellEnchantments is [])
        {
            foreach (var eName in BestTurtleShellEnchantmentNames)
            {
                var enchantment = Enchantments.FirstOrDefault(e => e.Name == eName);

                if (enchantment is not null)
                {
                    BestTurtleShellEnchantments.Add(enchantment);
                }
            }
        }
    }

    private Task<IEnumerable<Enchantment>> Search(string value, CancellationToken cancellationToken) =>
        Task.FromResult(string.IsNullOrEmpty(value)
            ? Enchantments
                .OrderBy(i => i.DisplayName)
                .Take(10)
            : Enchantments
                .Where(enchantment => enchantment.DisplayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.DisplayName));

    private Item? GetItem(string itemName) => string.IsNullOrEmpty(itemName)
        ? null
        : Items
            .FirstOrDefault(item => item.DisplayName
                .Equals(itemName.Trim(), StringComparison.InvariantCultureIgnoreCase));

    private string GenerateGiveEnchantedItemCommand(string itemName, List<Enchantment> enchantments, int level) =>
        CommandService.GenerateGiveEnchantedItemCommand(
            itemName,
            enchantments
                .Select(e => new EnchantmentModel { Name = e.Name, Level = level }).ToList());

    private static string ToString(Enchantment? enchantment) =>
        enchantment?.DisplayName ?? string.Empty;

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
