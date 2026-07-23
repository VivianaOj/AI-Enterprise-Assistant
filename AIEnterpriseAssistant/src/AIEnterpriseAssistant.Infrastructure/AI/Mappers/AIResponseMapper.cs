using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Responses;
using OpenAI.Chat;

namespace AIEnterpriseAssistant.Infrastructure.AI.Mappers;

public class AIResponseMapper
{
    public AIResponse Map(ChatCompletion completion)
    {
        return new AIResponse
        {
            Content = completion.Content?.ToString() ?? string.Empty,
            FinishReason = completion.FinishReason.ToString(),

            Usage = new AIUsage
            {
                PromptTokens = completion.Usage.InputTokenCount,
                CompletionTokens = completion.Usage.OutputTokenCount,
                TotalTokens = completion.Usage.TotalTokenCount
            }
        };
    }
}