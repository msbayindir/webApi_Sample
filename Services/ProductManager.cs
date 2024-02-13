using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatrues;
using Repositories.Contracts;
using Services.Contract;

namespace Services;
public class ProductManager : IProductService
{

    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    private readonly IDataShaper<ProductDto> _dataShaper;

    public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<ProductDto> dataShaper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
        _dataShaper = dataShaper;
    }

    public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion product)
    {

        _manager.Product.CreateOneProduct(_mapper.Map<Product>(product));
        await  _manager.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteOneProduct(int id, bool trackChange)
    {
        var entity = await _manager.Product.GetOneProductByIdAsync(id, trackChange);
        if (entity is null) throw new ProductNotFoundException(id);
        
        _manager.Product.DeleteOneProduct(entity);
        await _manager.SaveAsync();
    }

    public async Task<List<ProductDto>> GetProductsAsync(bool trackChange)
    {
        var products = await _manager.Product.GetProductsAsync(trackChange);
        var productsDtos = _mapper.Map<List<ProductDto>>(products);
        return productsDtos;
    }

    public async Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChange)
    {
        var entity =await _manager.Product.GetOneProductByIdAsync(id, trackChange);
        if (entity is null) throw new ProductNotFoundException(id);
        return _mapper.Map<ProductDto>(entity);
    }

    public async   Task<(IEnumerable<ExpandoObject>,MetaData)> GetProductsAsync(ProductParameters parameters,bool trackChange)
    {
        if(!parameters.ValidPriceRange)throw new PriceOutofRangeException();
        var a = await _manager.Product.GetProductsAsync(parameters,trackChange);
        var y = _mapper.Map<IEnumerable<ProductDto>>(a);
        var shapedData = _dataShaper.ShapeData(y, parameters.Fields);
        return (shapedData,a.MetaData);

    }

    public async void UpdateOneProduct(int id, ProductDtoForUpdate productDto, bool trackChange)
    {
        var entity = await _manager.Product.GetOneProductByIdAsync(id, trackChange);
        if (entity is null) throw new ProductNotFoundException(id);
        entity = _mapper.Map<Product>(productDto);
        _manager.Product.Update(entity);
        await _manager.SaveAsync();

    }

   
}

