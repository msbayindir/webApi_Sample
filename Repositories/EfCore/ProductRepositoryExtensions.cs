using Entities.Models;

namespace Repositories.EfCore;

public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> FilterProduct(this IQueryable<Product> books, uint minPrice, uint maxPrice) =>
        books.Where(b => (b.Price >= minPrice) && (b.Price <= maxPrice));
}