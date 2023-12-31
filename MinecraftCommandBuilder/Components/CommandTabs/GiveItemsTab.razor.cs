namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GiveItemsTab
{
    private List<Item> Items { get; set; } = [];

    private Item? SelectedItem { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Items is [])
        {
            Items = await ItemRepository.GetAllItems() ?? [];
        }
    }

    private void OnSelectedValuesChanged(IEnumerable<Item> values) =>
        SelectedItem = values?.FirstOrDefault();

    private bool GenerateCommandDisabled => SelectedItem is null;

    private void GenerateCommand()
    {
        if (SelectedItem is null)
        {
            return;
        }

        CommandService.SetGiveItemCommand("@s", SelectedItem.name, 1);
    }
}
