using AIEnterpriseAssistant.Application.Contracts.Requests;

namespace AIEnterpriseAssistant.Application.Interfaces;

public interface IRequestRouter
{
    /// <summary>
    /// Routes a chat request to the appropriate AI provider based on the request's context and configuration.
    /// </summary>
    Task<ChatMode> RouteRequestAsync(ChatRequest request);
}