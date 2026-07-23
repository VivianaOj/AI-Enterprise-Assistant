namespace AIEnterpriseAssistant.Infrastructure.Search;

public sealed class AzureAISearchOptions
{
    public const string SectionName = "AzureAISearch";
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string IndexName { get; init; } = string.Empty;

}