namespace MinecraftCommandBuilder.Pages;

public partial class Home
{
    private string CommandText { get; set; } = string.Empty;

    private List<MinecraftDataCSharp.Block> Blocks { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        if (Blocks is [])
        {
            Blocks = await BlockRepository.GetAllBlocks() ?? [];
        }
    }

    private void ChangeCommandText() => CommandText = CommandService.GiveCommand("@s", "apple", 1);
}
