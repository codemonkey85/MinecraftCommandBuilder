namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GiveItemsTab
{
    private List<Item> Items { get; set; } = [];

    private string PlayerName { get; set; } = "@s";

    private Item? SelectedItem { get; set; }

    private int Count { get; set; } = 1;

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

        CommandService.SetGiveItemCommand(PlayerName, SelectedItem.name, Count);
    }
}
