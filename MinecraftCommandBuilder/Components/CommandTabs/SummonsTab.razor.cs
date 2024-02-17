namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class SummonsTab
{
    private List<Entity> Entities { get; set; } = [];

    private Entity? SelectedEntity { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Entities is [])
        {
            Entities = await EntityRepository.GetAllEntities() ?? [];
        }
    }

    private void OnSelectedValuesChanged(IEnumerable<Entity> values) =>
        SelectedEntity = values?.FirstOrDefault();

    private bool GenerateCommandDisabled => SelectedEntity is null;

    private async Task<IEnumerable<Entity>> Search(string value)
    {
        await Task.Yield();

        return string.IsNullOrEmpty(value)
            ? Entities
            .OrderBy(i => i.displayName)
            .Take(10)

            : (IEnumerable<Entity>)Entities
                .Where(entity => entity.displayName
                    .StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(i => i.displayName);
    }

    private static string ToString(Entity? entity) =>
        entity?.displayName ?? string.Empty;

    private async Task GenerateCommand()
    {
        if (SelectedEntity is null)
        {
            return;
        }

        CommandService.SetSummonCommand(SelectedEntity.name);
        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
