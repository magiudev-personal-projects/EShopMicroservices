using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.GetProductsByCategory;

public static class GetProductsByCategoryRoute
{
    public static async void UseGetProductsByCategoryRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products/categories/{category}", async ([FromRoute] string category, ISender sender) =>
        {            
            var query = new GetProductsByCategoryQuery(category);
            var result = await sender.Send(query);
            var reponse = GetProductsByCategoryMaps.FromResultToResponse(result);
            return reponse;
        })
            .WithName("Get Products by Category")
            .Produces<GetProductsByCategoryResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Get Products by Category");
    }
}
