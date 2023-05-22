using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services;
public class ProductManager : IProductService
{

    private readonly IRepositoryManager _manager;

    public ProductManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public Product CreateOneProduct(Product product)
    {
        _manager.Product.CreateOneProduct(product);
        _manager.Save();
        return product;
    }

    public void DeleteOneProduct(int id, bool trackChange)
    {
        var entity = _manager.Product.GetOneProductById(id, trackChange).SingleOrDefault();
        if (entity is null) throw new Exception($"Product {id} couldn't found.");

        _manager.Product.DeleteOneProduct(entity);
        _manager.Save();
    }

    public Product GetOneProductById(int id, bool trackChange)
    {
        var entity = _manager.Product.GetOneProductById(id, trackChange).SingleOrDefault();
        if (entity is null) throw new Exception($"Product {id} couldn't found.");
        return entity;
    }

    public IQueryable<Product> GetProducts(bool trackChange)
    {
       return _manager.Product.GetProducts(trackChange);

    }

    public void UpdateOneProduct(int id, Product product, bool trackChange)
    {
        _manager.Product.UpdateOneProduct(product);
        _manager.Save();
    }
}

