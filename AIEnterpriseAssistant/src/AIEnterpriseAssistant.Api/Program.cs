using System.ClientModel;
using AIEnterpriseAssistant.Application.Interfaces;
using AIEnterpriseAssistant.Infrastructure.AI;
using AIEnterpriseAssistant.Infrastructure.AI.Mappers;
using AIEnterpriseAssistant.Infrastructure.Configuration;
using AIEnterpriseAssistant.Infrastructure.Search;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and OpenAPI/Swagger support
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure Azure OpenAI options
builder.Services.Configure<AzureOpenAIOptions>(builder.Configuration.GetSection(AzureOpenAIOptions.SectionName));

// Register Azure OpenAI client as singleton
builder.Services.AddSingleton(sp =>
{
    var options = sp
        .GetRequiredService<IOptions<AzureOpenAIOptions>>()
        .Value;

    return new AzureOpenAIClient(
        new Uri(options.Endpoint),
        new ApiKeyCredential(options.ApiKey));
});

// Register mappers
builder.Services.AddSingleton<PromptMapper>();
builder.Services.AddSingleton<AIResponseMapper>();

// Register AI client adapter
builder.Services.AddScoped<IAIClient, AzureOpenAIAdapter>();

builder.Services.Configure<AzureAISearchOptions>(
    builder.Configuration.GetSection(
        AzureAISearchOptions.SectionName));
builder.Services.AddSingleton<SearchDocumentMapper>();
builder.Services.AddScoped<ISearchService, AzureAISearchService>();

var app = builder.Build();

// Map controllers and OpenAPI endpoint
app.MapControllers();
app.MapOpenApi();

// Welcome page at root
// Welcome page at root
app.MapGet("/", () => Results.Content("""
    <!DOCTYPE html>
    <html>
    <head><title>AI Enterprise Assistant API</title>
        <style>body{font-family:sans-serif;max-width:800px;margin:40px auto;padding:0 20px}
        h1{color:#2563eb}a{color:#2563eb}</style></head>
    <body>
        <h1>AI Enterprise Assistant API</h1>
        <p>API running successfully.</p>
        <ul>
            <li><a href="/openapi/v1.json">OpenAPI Spec (JSON)</a></li>
            <li><code>POST /api/chat</code> - Ask a question</li>
        </ul>
    </body></html>
    """, "text/html"));

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Run();

