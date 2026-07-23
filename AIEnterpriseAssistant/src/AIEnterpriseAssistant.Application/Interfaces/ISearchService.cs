using AIEnterpriseAssistant.Application.Search;

namespace AIEnterpriseAssistant.Application.Interfaces;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken = default);
}