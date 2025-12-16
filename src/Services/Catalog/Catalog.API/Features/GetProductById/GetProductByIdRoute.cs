using Catalog.API.Features.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.GetProducts;

public static class GetProductById
{
    public static void UseGetProductByIdRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async ([FromRoute] Guid Id, ISender sender) =>
        {
            var query = new GetProductByIdQuery(Id);

            var result = await sender.Send(query);

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = GetProductByIdMaps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get product by id")
        .WithDescription("Get product by id");
    }
}
