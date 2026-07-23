public enum ChatMode
{
    /// <summary>
    /// Represents a chat mode that uses the Azure OpenAI service for generating responses.
    /// </summary>
    AzureOpenAI,

    /// <summary>
    /// Represents a chat mode that uses the OpenAI service for generating responses.
    /// </summary>
    OpenAI,

    /// <summary>
    /// Represents a chat mode that uses the Microsoft Bing Search API for generating responses.
    /// </summary>
    BingSearch
}