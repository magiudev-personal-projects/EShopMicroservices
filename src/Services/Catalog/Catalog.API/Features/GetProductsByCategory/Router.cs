using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.GetProductsByCategory;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products/categories/{category}", async ([FromRoute] string category, ISender sender) =>
        {            
            var query = new Query(category);
            var result = await sender.Send(query);
            var reponse = Maps.FromResultToResponse(result);
            return reponse;
        })
            .WithName("Get Products by Category")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Get Products by Category");
    }
}
