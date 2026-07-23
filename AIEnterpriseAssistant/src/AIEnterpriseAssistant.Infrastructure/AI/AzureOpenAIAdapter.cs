using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Responses;
using AIEnterpriseAssistant.Application.Interfaces;
using AIEnterpriseAssistant.Infrastructure.AI.Mappers;
using AIEnterpriseAssistant.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace AIEnterpriseAssistant.Infrastructure.AI;

public class AzureOpenAIAdapter : IAIClient
{
    private readonly ChatClient _chatClient;
    private readonly PromptMapper _promptMapper;
    private readonly AIResponseMapper _responseMapper;

    public AzureOpenAIAdapter(Azure.AI.OpenAI.AzureOpenAIClient azureClient, IOptions<AzureOpenAIOptions> options,
    PromptMapper promptMapper,
    AIResponseMapper responseMapper)
    {
        _promptMapper = promptMapper;
        _responseMapper = responseMapper;
        _chatClient = azureClient.GetChatClient(options.Value.DeploymentName);
    }

    public async Task<AIResponse> CompleteAsync(
     Prompt prompt,
     CancellationToken cancellationToken)
    {
        var messages = _promptMapper.Map(prompt);

        var options = CreateOptions(prompt);

        var completion = await _chatClient.CompleteChatAsync(
            messages,
            options,
            cancellationToken);

        return _responseMapper.Map(completion);
    }

    private ChatCompletionOptions CreateOptions(
    Prompt prompt)
    {
        return new ChatCompletionOptions
        {
            Temperature = prompt.Temperature,
            MaxOutputTokenCount = prompt.MaxTokens,
            TopP = prompt.TopP
        };
    }
}