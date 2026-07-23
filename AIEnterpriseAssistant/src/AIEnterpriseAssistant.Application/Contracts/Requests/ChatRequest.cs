namespace AIEnterpriseAssistant.Application.Contracts.Requests;

public sealed class ChatRequest
{
    public required string UserId { get; init; }

    public required string Message { get; init; }

    public string? ConversationId { get; init; }
}