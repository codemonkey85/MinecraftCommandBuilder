namespace MinecraftCommandBuilder.Components.CommandTabs;

public partial class ExperimentalTab
{
    public const string TabTitle = "Experimental";

    private string UserInputText = string.Empty;

    private string ChatOutputText = string.Empty;

    List<ChatMessage> messages = [new(ChatRole.System, """
    You are a helpful assistant for Minecraft command building. Your task is to assist users in creating Minecraft commands based on their input.
    You should provide clear and concise responses, and if the user asks for help with a specific command, you should guide them through the process of building that command step by step.
    If the user asks for help with a specific command, you should ask them for more details about what they want to achieve.
    """)];

    private Task GetResponseFromChat()
    {
        if (string.IsNullOrWhiteSpace(UserInputText))
        {
            return Task.CompletedTask;
        }

        return Task.CompletedTask;

        //messages.Add(new ChatMessage(ChatRole.User, UserInputText));

        //var response = await ChatClient.GetResponseAsync(messages);

        //if (response is not null)
        //{
        //    messages.Add(new ChatMessage(ChatRole.Assistant, response.Text));
        //    ChatOutputText = response.Text;
        //}
        //else
        //{
        //    ChatOutputText = "No response received.";
        //}
    }
}
