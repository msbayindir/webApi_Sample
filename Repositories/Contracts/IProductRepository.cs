using System;
using Entities.Models;
using Entities.RequestFeatrues;

namespace Repositories.Contracts
{
	public interface IProductRepository:IRepositoryBase<Product>
	{
        Task<PagedList<Product>> GetProductsAsync(ProductParameters parameters,bool trackChange);
        Task<Product> GetOneProductByIdAsync(int id, bool trackChange);
        public void CreateOneProduct(Product product);
        public void UpdateOneProduct(Product product);
        public void DeleteOneProduct(Product product);

    }
}

