namespace AIEnterpriseAssistant.Application.Search;

public sealed class SearchResultDocument
{
    public string Id { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;

    public double? Score { get; init; }
}