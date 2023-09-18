using System;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contract
{
	public interface IProductService
	{
        Task<IEnumerable<ProductDto>> GetProductsAsync(bool trackChange);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChange);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion product);
        void UpdateOneProduct(int id,ProductDtoForUpdate productDto,bool trackChange);
        void DeleteOneProduct(int id,bool trackChange);
    }
}

