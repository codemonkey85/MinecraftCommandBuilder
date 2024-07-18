namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GiveItemsTab
{
    private List<Item> Items { get; set; } = [];

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

    private async Task<IEnumerable<Item>> Search(string value, CancellationToken cancellationToken)
    {
        await Task.Yield();

        return string.IsNullOrEmpty(value)
            ? Items
            .OrderBy(i => i.displayName)
            .Take(10)

            : (IEnumerable<Item>)Items
                .Where(item => item.displayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.displayName);
    }

    private static string ToString(Item? item) =>
        item?.displayName ?? string.Empty;

    private bool GenerateCommandDisabled => SelectedItem is null;

    private async Task GenerateCommand()
    {
        if (SelectedItem is null)
        {
            return;
        }

        CommandService.SetGiveItemCommand(
            SelectedItem.name,
            Count);

        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
