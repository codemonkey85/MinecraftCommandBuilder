namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class SummonsTab
{
    public const string TabTitle = "Summons";

    private List<Entity> Entities { get; set; } = [];

    private Entity? SelectedEntity { get; set; }

    private bool GenerateCommandDisabled => SelectedEntity is null;

    private async Task<IEnumerable<Entity>> Search(string value, CancellationToken cancellationToken)
    {
        Entities = await EntityRepository.GetAllEntities();

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
