namespace AIEnterpriseAssistant.Infrastructure.Search;

public sealed class AzureSearchDocument{
    public string Id { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;
}