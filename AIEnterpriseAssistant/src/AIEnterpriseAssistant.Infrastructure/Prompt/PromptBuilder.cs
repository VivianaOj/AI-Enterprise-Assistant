using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Requests;
using AIEnterpriseAssistant.Application.Interfaces;

namespace AIEnterpriseAssistant.Infrastructure.AI;

public sealed class PromptBuilder : IPromptBuilder
{
    public Prompt Build(ChatRequest request)
    {
        var prompt = new Prompt
        {
            Temperature = 0.2F,
            MaxTokens = 1000,
            TopP = 1.0F,
        };

        prompt.Messages.Add(new PromptMessage
        {
            Role = "System",
            Content = """
                You are an enterprise AI assistant.

                Answer clearly and professionally.

                If you don't know the answer, say so.

                Never invent information.
                """
        });

        prompt.Messages.Add(new PromptMessage
        {
            Role = "User",
            Content = request.Message
        });

        return prompt;
    }
}