namespace AIEnterpriseAssistant.Application.Search;

public sealed class SearchResponse
{
    public IReadOnlyList<SearchResultDocument> Documents { get; init; }
        = [];
}