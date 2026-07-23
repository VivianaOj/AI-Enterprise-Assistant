using AIEnterpriseAssistant.Application.Contracts.Requests;
using AIEnterpriseAssistant.Application.Contracts.Responses;

namespace AIEnterpriseAssistant.Application.UseCases.AskQuestion;

public interface IAskQuestionUseCase
{
    Task<ChatResponse> ExecuteAsync(
        ChatRequest request,
        CancellationToken cancellationToken = default);
}