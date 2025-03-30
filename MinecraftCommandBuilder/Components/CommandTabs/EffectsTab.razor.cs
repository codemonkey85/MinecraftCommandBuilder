namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class EffectsTab
{
    private List<Effect> Effects { get; set; } = [];

    private Effect? SelectedEffect { get; set; }

    private int Duration { get; set; } = 60;

    private int Amplifier { get; set; } = 1;

    private bool ClearEffect { get; set; }

    private bool GenerateCommandDisabled => SelectedEffect is null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Effects is [])
        {
            await RefreshEffectsList();
        }
    }

    private async Task RefreshEffectsList() => Effects = await EffectRepository.GetAllEffects();

    private void OnSelectedValuesChanged(IEnumerable<Effect?>? values) =>
        SelectedEffect = values?.FirstOrDefault();

    private async Task GenerateCommand()
    {
        if (SelectedEffect is null)
        {
            return;
        }

        CommandService.SetEffectCommand(
            SelectedEffect.BedrockName,
            Duration,
            Amplifier,
            ClearEffect);

        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }

    private void GenerateClearAllEffectsCommand() =>
        CommandService.SetClearAllEffectsCommand();
}
