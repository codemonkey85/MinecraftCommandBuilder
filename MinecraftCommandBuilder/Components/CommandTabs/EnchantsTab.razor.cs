namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EnchantsTab
{
    private List<Enchantment> Enchantments { get; set; } = [];

    private Enchantment? SelectedEnchantment { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Enchantments is [])
        {
            Enchantments = await EnchantmentRepository.GetAllEnchantments() ?? [];
        }
    }

    private void OnSelectedValuesChanged(IEnumerable<Enchantment> values) =>
        SelectedEnchantment = values?.FirstOrDefault();

    private bool GenerateCommandDisabled => SelectedEnchantment is null;

    private void GenerateCommand()
    {
        if (SelectedEnchantment is null)
        {
            return;
        }

        CommandService.SetEnchantCommand("@s", SelectedEnchantment.name, 1);
    }
}
