using System;
using System.Dynamic;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatrues;

namespace Services.Contract
{
	public interface IProductService
	{
        Task<(IEnumerable<ExpandoObject>,MetaData)> GetProductsAsync(ProductParameters parameters,bool trackChange);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChange);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion product);
        void UpdateOneProduct(int id,ProductDtoForUpdate productDto,bool trackChange);
        Task DeleteOneProduct(int id,bool trackChange);
        Task<List<ProductDto>> GetProductsAsync(bool trackChange);
    }
}

