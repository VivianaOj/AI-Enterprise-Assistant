using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Responses;

namespace AIEnterpriseAssistant.Application.Interfaces;

public interface IAIClient
{
    Task<AIResponse> CompleteAsync(Prompt prompt, CancellationToken cancellationToken = default);      
}