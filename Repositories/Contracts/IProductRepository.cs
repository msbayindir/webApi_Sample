using System;
using Entities.Models;

namespace Repositories.Contracts
{
	public interface IProductRepository:IRepositoryBase<Product>
	{
        IQueryable<Product> GetProducts(bool trackChange);
        IQueryable<Product> GetOneProductById(int id, bool trackChange);
        public void CreateOneProduct(Product product);
        public void UpdateOneProduct(Product product);
        public void DeleteOneProduct(Product product);

    }
}

