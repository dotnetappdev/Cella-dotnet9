using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

[Generator]
public class SwaggerSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context) { }

    public void Execute(GeneratorExecutionContext context)
    {
        var swaggerPath = context.AnalyzerConfigOptions.GlobalOptions.TryGetValue(
            "build_property.SwaggerSource", out var swaggerSource)
            ? swaggerSource
            : null;

        if (string.IsNullOrEmpty(swaggerSource)) return;

        string json;

        if (swaggerSource.StartsWith("http"))
        {
            // Download Swagger JSON from HTTP
            json = DownloadFromHttp(swaggerSource).GetAwaiter().GetResult();
        }
        else
        {
            // Read from local file
            if (!System.IO.File.Exists(swaggerSource)) return;
            json = System.IO.File.ReadAllText(swaggerSource);
        }

        if (string.IsNullOrEmpty(json)) return;

        var swagger = JsonDocument.Parse(json);
        var paths = swagger.RootElement.GetProperty("paths");

        var builder = new StringBuilder();

        foreach (var path in paths.EnumerateObject())
        {
            var url = path.Name;
            foreach (var method in path.Value.EnumerateObject())
            {
                var operationId = method.Value.GetProperty("operationId").GetString();
                if (string.IsNullOrEmpty(operationId)) continue;

                builder.AppendLine(GenerateBlazorComponent(url, operationId));
            }
        }

        // Emit the Razor content as a C# file that MSBuild will capture
        context.AddSource("GeneratedBlazorTemplate", SourceText.From(builder.ToString(), Encoding.UTF8));
    }

    private async Task<string> DownloadFromHttp(string url)
    {
        using var client = new HttpClient();
        return await client.GetStringAsync(url);
    }

    private string GenerateBlazorComponent(string url, string operationId)
    {
        return $@"
@page ""{url}""
@inject MyApiClient ApiClient

<h3>{operationId}</h3>
<button @onclick=""Handle{operationId}"">Call {operationId}</button>

@code {{
    private async Task Handle{operationId}() 
    {{
        var result = await ApiClient.{operationId}();
        Console.WriteLine(result);
    }}
}}
";
    }
}
