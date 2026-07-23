namespace AIEnterpriseAssistant.Application.Contracts;

public sealed class Prompt
{
    public List<PromptMessage> Messages { get; } = new();

    public float Temperature { get; init; } = 0.7f;

    public int MaxTokens { get; init; } = 1000;

    public float TopP { get; init; } = 1f;
}

public sealed class PromptMessage
{
    public string Role { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;
}