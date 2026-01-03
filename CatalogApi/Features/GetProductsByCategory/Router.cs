using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Features.GetProductsByCategory;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products/categories/{category}", async ([FromRoute] string category, ISender sender) =>
        {            
            var query = new Query(category);
            var result = await sender.Send(query);
            var response = Maps.FromResultToResponse(result);
            return Results.Ok(response);

        })
            .WithName("GetProductsbyCategory")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
    }
}
