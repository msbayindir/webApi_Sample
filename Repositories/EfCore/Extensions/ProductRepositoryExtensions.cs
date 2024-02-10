using Entities.Models;
using System.Linq.Dynamic.Core;
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

    public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return products.OrderBy(b => b.Id);

        var orderQuery = OrderQueryBuilder
            .CreateOrderQuery<Product>(orderByQueryString);

        if (orderQuery is null)
            return products.OrderBy(b => b.Id);

        return products.OrderBy(orderQuery);
    }
}