using AIEnterpriseAssistant.Application.Contracts;
using AIEnterpriseAssistant.Application.Contracts.Requests;
using AIEnterpriseAssistant.Application.Contracts.Responses;
using AIEnterpriseAssistant.Application.Search;

namespace AIEnterpriseAssistant.Application.Interfaces;

public interface IPromptBuilder
{
    Prompt  Build(
    ChatRequest request);
}