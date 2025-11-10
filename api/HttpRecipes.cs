using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api;

public class HttpRecipes
{
    private readonly ILogger<HttpRecipes> _logger;

    public HttpRecipes(ILogger<HttpRecipes> logger)
    {
        _logger = logger;
    }

    [Function("HttpRecipes")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome 2 Azure Functions! Trying to make the http recipe work.");
    }
}
