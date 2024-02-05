using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
namespace Repositories.EfCore
{
	public class ProductRepository:RepositoryBase<Product>,IProductRepository
	{

		public ProductRepository(RepositoryContext context):base(context)
		{

		}

        public void CreateOneProduct(Product product) => Create(product);


        public void DeleteOneProduct(Product product) => Delete(product);


        public async Task<IEnumerable<Product>> GetProductsAsync(bool trackChange)
        {
            return await GetValues(trackChange).ToListAsync();
        }

        public async Task<Product?> GetOneProductByIdAsync(int id, bool trackChange) => await FindByConditional(b => b.Id.Equals(id), trackChange).SingleOrDefaultAsync();

        public void UpdateOneProduct(Product product)=>
         Update(product);

        
    }
}

