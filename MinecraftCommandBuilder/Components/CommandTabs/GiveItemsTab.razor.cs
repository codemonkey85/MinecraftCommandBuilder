namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class GiveItemsTab
{
    public const string TabTitle = "Give Items";

    private List<Item> Items { get; set; } = [];

    private Item? SelectedItem { get; set; }

    private int Count { get; set; } = 1;

    private bool GenerateCommandDisabled => SelectedItem is null;

    private async Task<IEnumerable<Item>> Search(string value, CancellationToken cancellationToken)
    {
        Items = await ItemRepository.GetAllItems();

        return string.IsNullOrEmpty(value)
            ? Items
                .OrderBy(i => i.DisplayName)
                .Take(10)
            : Items
                .Where(item => item.DisplayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.DisplayName);
    }

    private static string ToString(Item? item) =>
        item?.DisplayName ?? string.Empty;

    private async Task GenerateCommand()
    {
        if (SelectedItem is null)
        {
            return;
        }

        CommandService.SetGiveItemCommand(
            SelectedItem.Name,
            Count);

        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
