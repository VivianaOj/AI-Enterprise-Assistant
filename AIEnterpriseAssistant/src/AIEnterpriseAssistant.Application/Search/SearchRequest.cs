namespace AIEnterpriseAssistant.Application.Search;

public sealed class SearchRequest
{
    public required string Query { get; init; }
    public string? ConversationId { get; init; }

    public string? Context { get; init; }
}