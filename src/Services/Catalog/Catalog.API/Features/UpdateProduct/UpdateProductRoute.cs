using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.UpdateProduct;

public static class UpdateProductRoute
{
    public static void UseUpdateProductRoute(this IEndpointRouteBuilder app)
    {
        app.MapPut("/Products", async ([FromBody] Request request, ISender sender) =>
        {
           var command = UpdateProductMaps.FromRequestToCommand(request);
           var result = await sender.Send(command);
           var response = UpdateProductMaps.FromResultToResponse(result);
           return response;
        });
    }
}