using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using System.IO;
// using System.Text.Json;

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

        // Read the recipes from the JSON file
        /*
        string jsonFilePath = Path.Combine("api", "recipes.json");
        var json = File.ReadAllText(jsonFilePath);
        var recipes = JsonSerializer.Deserialize<Recipe[]>(json);
        */

        // Example recipe with required members set

        Recipe[] recipes = new[]
        {
            new Recipe { Id = "1", Title = "Spaghetti Bolognese", Description = "A classic Italian pasta dish." },
            new Recipe { Id = "2", Title = "Chicken Curry", Description = "A spicy and flavorful dish." }
        };

        return new OkObjectResult(recipes); // Return the recipes as JSON
    }
}
