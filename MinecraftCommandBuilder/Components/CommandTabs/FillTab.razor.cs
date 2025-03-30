namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class FillTab
{
    private int Width { get; set; }

    private int Height { get; set; }

    private int Depth { get; set; }

    private List<Block> Blocks { get; set; } = [];

    private Block? SelectedBlock { get; set; }

    private bool GenerateCommandDisabled => SelectedBlock is null;

    private async Task<IEnumerable<Block>> Search(string value, CancellationToken cancellationToken)
    {
        Blocks = await BlockRepository.GetAllBlocks();

        return string.IsNullOrEmpty(value)
            ? Blocks
                .OrderBy(i => i.DisplayName)
                .Take(10)
            : Blocks
                .Where(block => block.DisplayName
                    .Contains(value.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(b => b.DisplayName);
    }

    private static string ToString(Block? block) =>
        block?.DisplayName ?? string.Empty;

    private async Task GenerateCommand()
    {
        if (SelectedBlock is null)
        {
            return;
        }

        string? x1;
        string? x2;
        if (Width > 0)
        {
            x1 = "~";
            x2 = $"~+{Width - 1}";
        }
        else
        {
            x1 = $"~+{Width + 1}";
            x2 = "~";
        }

        string? y1;
        string? y2;
        if (Height > 0)
        {
            y1 = "~";
            y2 = $"~+{Height - 1}";
        }
        else
        {
            y1 = $"~+{Height + 1}";
            y2 = "~";
        }

        string? z1;
        string? z2;
        if (Depth > 0)
        {
            z1 = "~";
            z2 = $"~+{Depth - 1}";
        }
        else
        {
            z1 = $"~+{Depth + 1}";
            z2 = "~";
        }

        CommandService.SetFillCommand(x1, y1, z1, x2, y2, z2, SelectedBlock.Name);
        await CommandService.CopyTextToClipboard(CommandService.CommandText);
    }
}
