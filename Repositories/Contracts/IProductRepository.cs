using System;
using Entities.Models;

namespace Repositories.Contracts
{
	public interface IProductRepository:IRepositoryBase<Product>
	{
        Task<IEnumerable<Product>> GetProductsAsync(bool trackChange);
        Task<Product> GetOneProductByIdAsync(int id, bool trackChange);
        public void CreateOneProduct(Product product);
        public void UpdateOneProduct(Product product);
        public void DeleteOneProduct(Product product);

    }
}

