using AIEnterpriseAssistant.Application.Contracts.Requests;
using FluentValidation;

namespace AIEnterpriseAssistant.Application.Validators;

public class ChatRequestValidator : AbstractValidator<ChatRequest>
{
    public ChatRequestValidator()
    {
        RuleFor(request => request.Message)
            .NotEmpty().WithMessage("Message cannot be empty.")
            .MaximumLength(1000).WithMessage("Message cannot exceed 1000 characters.");

        RuleFor(request => request.ConversationId)
            .NotEmpty().WithMessage("ConversationId cannot be empty.");
    }
}