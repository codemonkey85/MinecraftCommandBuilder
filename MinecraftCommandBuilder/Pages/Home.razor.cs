namespace MinecraftCommandBuilder.Pages;

public partial class Home
{
    private string CommandText { get; set; } = string.Empty;

    private List<Block> Blocks { get; set; } = [];

    private List<Effect> Effects { get; set; } = [];

    private List<Item> Items { get; set; } = [];

    private List<Biome> BiomesList { get; set; } = [];

    private List<Entity> EntitiesList { get; set; } = [];

    private List<Enchantment> EnchantmentsList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        if (Blocks is [])
        {
            Blocks = await BlockRepository.GetAllBlocks() ?? [];
        }
        if (Effects is [])
        {
            Effects = await EffectRepository.GetAllEffects() ?? [];
        }
        if (Items is [])
        {
            Items = await ItemRepository.GetAllItems() ?? [];
        }
        if (BiomesList is [])
        {
            BiomesList = await BiomeRepository.GetAllBiomes() ?? [];
        }
        if (EntitiesList is [])
        {
            EntitiesList = await EntityRepository.GetAllEntities() ?? [];
        }
        if (EnchantmentsList is [])
        {
            EnchantmentsList = await EnchantmentRepository.GetAllEnchantments() ?? [];
        }
    }

    private void ChangeCommandText() =>
        CommandText = CommandService.GiveCommand("@s", "apple", 1);
}
