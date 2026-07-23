namespace AIEnterpriseAssistant.Application.Contracts.Responses;

public sealed class ChatResponse
{
    public required string Message { get; init; }

    public string? ConversationId { get; init; }

    public AIUsage? Usage { get; init; }
}