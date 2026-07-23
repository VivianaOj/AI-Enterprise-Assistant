namespace AIEnterpriseAssistant.Application.Contracts.Responses;

public sealed class AIResponse
{
    public Guid RequestId { get; init; }

    public string Content { get; init; } = string.Empty;

    public string Model { get; init; } = string.Empty;

    public string? FinishReason { get; init; }


    public DateTimeOffset CreatedAt { get; init; }
    public AIUsage Usage { get; init; } = new();
}
