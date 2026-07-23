using AIEnterpriseAssistant.Application.Search;

namespace AIEnterpriseAssistant.Infrastructure.Search;

public sealed class SearchDocumentMapper
{
    public SearchResultDocument Map(
        AzureSearchDocument document,
        double? score)
    {
        ArgumentNullException.ThrowIfNull(document);

        return new SearchResultDocument
        {
            Id = document.Id,
            Title = document.Title,
            Content = document.Content,
            Score = score
        };
    }
}

