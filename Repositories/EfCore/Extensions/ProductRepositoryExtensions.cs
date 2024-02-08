using Entities.Models;
using Microsoft.IdentityModel.Tokens;

namespace Repositories.EfCore.Extensions;

public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> FilterProduct(this IQueryable<Product> products, uint minPrice, uint maxPrice) =>
        products.Where(b => (b.Price >= minPrice) && (b.Price <= maxPrice));

    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm) =>
        !string.IsNullOrWhiteSpace(searchTerm)
            ? products.Where(b => b.ProductName
                .Trim()
                .ToLower()
                .Contains(searchTerm
                    .Trim()
                    .ToLower()))
            : products;

}