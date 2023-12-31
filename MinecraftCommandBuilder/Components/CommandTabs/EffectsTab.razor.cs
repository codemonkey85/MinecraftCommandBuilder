namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EffectsTab
{
    private List<Effect> Effects { get; set; } = [];

    private Effect? SelectedEffect { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Effects is [])
        {
            Effects = await EffectRepository.GetAllEffects() ?? [];
        }
    }

    private void OnSelectedValuesChanged(IEnumerable<Effect> values) =>
        SelectedEffect = values?.FirstOrDefault();

    private bool GenerateCommandDisabled => SelectedEffect is null;

    private void GenerateCommand()
    {
        if (SelectedEffect is null)
        {
            return;
        }

        CommandService.SetEffectCommand("@s", SelectedEffect.name, 100, 1);
    }
}
