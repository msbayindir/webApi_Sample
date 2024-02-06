using System;
using Entities.Models;
using Entities.RequestFeatrues;
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


        public async Task<PagedList<Product>> GetProductsAsync(ProductParameters parameters,bool trackChange)
        {
	        var products =  await GetValues(trackChange)
		        .ToListAsync();
	       return PagedList<Product>
		       .ToPagedList(products,parameters.PageNumber,parameters.PageSize);

        }

        public async Task<Product?> GetOneProductByIdAsync(int id, bool trackChange) => await FindByConditional(b => b.Id.Equals(id), trackChange).SingleOrDefaultAsync();

        public void UpdateOneProduct(Product product)=>
         Update(product);

        
    }
}

