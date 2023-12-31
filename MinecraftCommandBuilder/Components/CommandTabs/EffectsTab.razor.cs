namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EffectsTab
{
    private List<Effect> Effects { get; set; } = [];

    private string PlayerName { get; set; } = "@s";

    private Effect? SelectedEffect { get; set; }

    private int Duration { get; set; } = 100;

    private int Amplifier { get; set; } = 1;

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

        CommandService.SetEffectCommand(PlayerName, SelectedEffect.name, Duration, Amplifier);
    }
}
