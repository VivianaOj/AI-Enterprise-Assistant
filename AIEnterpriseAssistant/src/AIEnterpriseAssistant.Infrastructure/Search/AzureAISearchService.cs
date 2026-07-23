

using Azure;
using Azure.Search.Documents;
using Microsoft.Extensions.Options;
using AIEnterpriseAssistant.Application.Interfaces;
using AIEnterpriseAssistant.Application.Search;
namespace AIEnterpriseAssistant.Infrastructure.Search;

public sealed class AzureAISearchService : ISearchService
{
    private readonly SearchClient _searchClient;
    private readonly SearchDocumentMapper _mapper;

    public AzureAISearchService(
        IOptions<AzureAISearchOptions> options,
        SearchDocumentMapper mapper)
    {
        _mapper = mapper;

        var configuration = options.Value;

        _searchClient = new SearchClient(
            new Uri(configuration.Endpoint),
            configuration.IndexName,
            new AzureKeyCredential(configuration.ApiKey));
    }

    public async Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken = default)
    {
        var searchResults = await _searchClient.SearchAsync<AzureSearchDocument>(
            request.Query,
            cancellationToken: cancellationToken);

        var documents = new List<SearchResultDocument>();

        await foreach (var result in searchResults.Value.GetResultsAsync())
        {
            documents.Add(
                _mapper.Map(result.Document, result.Score));
        }

        return new SearchResponse
        {
            Documents = documents
        };
    }
}