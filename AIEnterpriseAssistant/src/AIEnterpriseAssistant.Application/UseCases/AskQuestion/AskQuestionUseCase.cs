using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Requests;
using AIEnterpriseAssistant.Application.Contracts.Responses;
using AIEnterpriseAssistant.Application.Interfaces;
using AIEnterpriseAssistant.Application.Search;

namespace AIEnterpriseAssistant.Application.UseCases.AskQuestion;
public sealed class AskQuestionUseCase : IAskQuestionUseCase
{
    private readonly IAIClient _aiClient;
    private readonly IPromptBuilder _promptBuilder;

    public AskQuestionUseCase(
        IAIClient aiClient,
        IPromptBuilder promptBuilder)
    {
        ArgumentNullException.ThrowIfNull(aiClient);
        ArgumentNullException.ThrowIfNull(promptBuilder);

        _aiClient = aiClient;
        _promptBuilder = promptBuilder;
    }

    public async Task<ChatResponse> ExecuteAsync(
        ChatRequest request,
        CancellationToken cancellationToken = default)
    {
        var prompt = _promptBuilder.Build(request);

        var aiResponse = await _aiClient.CompleteAsync(
            prompt,
            cancellationToken);

        return new ChatResponse
        {
            Message = aiResponse.Content,
            ConversationId = request.ConversationId
        };
    }
}