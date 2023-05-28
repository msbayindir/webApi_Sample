using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services;
public class ProductManager : IProductService
{

    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
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
        if (entity is null) throw new ProductNotFoundException(id);
        
        _manager.Product.DeleteOneProduct(entity);
        _manager.Save();
    }

    public Product GetOneProductById(int id, bool trackChange)
    {
        var entity = _manager.Product.GetOneProductById(id, trackChange).SingleOrDefault();
        if (entity is null) throw new ProductNotFoundException(id);
        
        return entity;
    }

    public IQueryable<Product> GetProducts(bool trackChange)
    {
       return _manager.Product.GetProducts(trackChange);

    }

    public void UpdateOneProduct(int id, ProductDtoForUpdate productDto, bool trackChange)
    {
        var entity = _manager.Product.GetOneProductById(id,trackChange).FirstOrDefault();
        if (entity is null) throw new ProductNotFoundException(id);
        entity = _mapper.Map<Product>(productDto);
        _manager.Product.Update(entity);
        _manager.Save();

    }

   
}

