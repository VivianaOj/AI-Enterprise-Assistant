namespace AIEnterpriseAssistant.Application.Contracts;

public sealed class AIUsage
{
    public int PromptTokens { get; init; }

    public int CompletionTokens { get; init; }

    public int TotalTokens { get; init; }
}