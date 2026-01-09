namespace MinecraftCommandBuilder.Models;

public class EnchantmentModel
{
    public required string Name { get; init; } = string.Empty;

    public int Level { get; init; } = 1;
}
