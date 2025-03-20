namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class SummonsTab
{
    private List<Entity> Entities { get; set; } = [];

    private Entity? SelectedEntity { get; set; }

    private bool GenerateCommandDisabled => SelectedEntity is null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Entities is [])
        {
            Entities = await EntityRepository.GetAllEntities();
        }
    }

    private async Task<IEnumerable<Entity>> Search(string value, CancellationToken cancellationToken)
    {
        await Task.Yield();

        return string.IsNullOrEmpty(value)
            ? Entities
                .OrderBy(i => i.DisplayName)
                .Take(10)
            : Entities
                .Where(entity => entity.DisplayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.DisplayName);
    }

    private static string ToString(Entity? entity) =>
        entity?.DisplayName ?? string.Empty;

    private async Task GenerateCommand()
    {
        if (SelectedEntity is null)
        {
            return;
        }

        CommandService.SetSummonCommand(SelectedEntity.Name);
        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
