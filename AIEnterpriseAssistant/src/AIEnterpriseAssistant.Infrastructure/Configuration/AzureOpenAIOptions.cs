namespace AIEnterpriseAssistant.Infrastructure.Configuration;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";

    public required string Endpoint { get; init; }

    public required string ApiKey { get; init; }

    public required string DeploymentName { get; init; }

    public int TimeoutInSeconds { get; init; } = 60;

    public bool EnableLogging { get; init; } = true;

    public string ApiVersion { get; init; } = "2025-01-01-preview";
}