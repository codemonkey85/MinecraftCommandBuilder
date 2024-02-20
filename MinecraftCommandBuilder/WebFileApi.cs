namespace MinecraftCommandBuilder;

/// <summary>
/// Used by MinecraftDataCSharp to read data from the Minecraft data files
/// </summary>
/// <param name="httpClient"></param>
public class WebFileApi(HttpClient httpClient) : IFileApi
{
    public Task<string> ReadAllText(string path) =>
        httpClient.GetStringAsync(path);
}
