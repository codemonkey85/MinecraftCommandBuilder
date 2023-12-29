namespace MinecraftCommandBuilder.Services;

public class CommandService : ICommandService
{
    public string GiveCommand(string playerName, string itemName, int count)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            throw new ArgumentException("Player name cannot be empty.", nameof(playerName));
        }

        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be empty.", nameof(itemName));
        }

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0.");
        }

        return $"/give {playerName} {itemName} {count}";
    }
}
