using MediatR;

namespace Catalog.API.Features.GetProducts;

public static class GetProducts
{
    public static void UseGetProductsRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuery();

            var result = await sender.Send(query);

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = GetProductsMaps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get all products")
        .WithDescription("Get all products");
    }
}
