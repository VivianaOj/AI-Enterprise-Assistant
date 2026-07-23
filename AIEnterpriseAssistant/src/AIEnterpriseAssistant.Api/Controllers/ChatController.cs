using AIEnterpriseAssistant.Application.Contracts.Requests;
using AIEnterpriseAssistant.Application.UseCases.AskQuestion;
using Microsoft.AspNetCore.Mvc;

namespace AIEnterpriseAssistant.Api.Controllers;

[ApiController]
[Route("api/chat")]
public sealed class ChatController : ControllerBase
{
    private readonly IAskQuestionUseCase _askQuestionUseCase;

    public ChatController(
        IAskQuestionUseCase askQuestionUseCase)
    {
        _askQuestionUseCase = askQuestionUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Ask(
        ChatRequest request,
        CancellationToken cancellationToken)
    {
        var response =
            await _askQuestionUseCase.ExecuteAsync(
                request,
                cancellationToken);

        return Ok(response);
    }
}