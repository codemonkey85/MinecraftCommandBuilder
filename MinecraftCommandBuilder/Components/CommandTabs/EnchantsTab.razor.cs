namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EnchantsTab
{
    private List<Enchantment> Enchantments { get; set; } = [];

    private Enchantment? SelectedEnchantment { get; set; }

    private int Level { get; set; } = 1;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Enchantments is [])
        {
            Enchantments = await EnchantmentRepository.GetAllEnchantments() ?? [];
        }
    }

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

    private async Task GenerateCommand()
    {
        if (SelectedEnchantment is null)
        {
            return;
        }

        CommandService.SetEnchantCommand(
            SelectedEnchantment.name,
            Level);

        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
