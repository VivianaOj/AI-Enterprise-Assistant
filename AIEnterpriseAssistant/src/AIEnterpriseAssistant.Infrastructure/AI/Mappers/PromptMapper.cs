using AIEnterpriseAssistant.Application.Contracts;
using OpenAI.Chat;

namespace AIEnterpriseAssistant.Infrastructure.AI.Mappers;

public sealed class PromptMapper
{

    public PromptMapper()
    {
    }

    public IReadOnlyList<OpenAI.Chat.ChatMessage> Map(Prompt prompt)
    {
        var messages = new List<OpenAI.Chat.ChatMessage>(prompt.Messages.Count);
        foreach (var message in prompt.Messages)
        {
            messages.Add(CreateMessage(message));
        }
        return messages;
    }

    private static OpenAI.Chat.ChatMessage CreateMessage(PromptMessage message)
    {
        var role = Enum.Parse<MessageRole>(message.Role, ignoreCase: true);
        return role switch
        {
            MessageRole.System => new SystemChatMessage(message.Content),
            MessageRole.User => new UserChatMessage(message.Content),
            MessageRole.Assistant => new AssistantChatMessage(message.Content),
            MessageRole.Tool => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}