using System;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contract
{
	public interface IProductService
	{
        IQueryable<ProductDto> GetProducts(bool trackChange);
        ProductDto GetOneProductById(int id, bool trackChange);
        ProductDto CreateOneProduct(ProductDtoForInsertion product);
        void UpdateOneProduct(int id,ProductDtoForUpdate productDto,bool trackChange);
        void DeleteOneProduct(int id,bool trackChange);
    }
}

