using Lesson_33_Commerce.Models.Business;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Lesson_33_Commerce.Controllers;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Products").WithTags(nameof(Product));

        group.MapGet("/", () =>
        {
            return new [] { new Product() };
        })
        .WithName("GetAllProducts")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Product { ID = id };
        })
        .WithName("GetProductById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Product input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateProduct")
        .WithOpenApi();

        group.MapPost("/", (Product model) =>
        {
            //return TypedResults.Created($"/api/Products/{model.ID}", model);
        })
        .WithName("CreateProduct")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Product { ID = id });
        })
        .WithName("DeleteProduct")
        .WithOpenApi();
    }
}
