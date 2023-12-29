namespace MinecraftCommandBuilder.Services;

public interface ICommandService
{
    string GiveCommand(string playerName, string itemName, int count);
}
