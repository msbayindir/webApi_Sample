using System;
using Entities.Models;
using Entities.RequestFeatrues;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;

namespace Repositories.EfCore
{
	public sealed class ProductRepository:RepositoryBase<Product>,IProductRepository
	{

		public ProductRepository(RepositoryContext context):base(context)
		{

		}

        public void CreateOneProduct(Product product) => Create(product);


        public void DeleteOneProduct(Product product) => Delete(product);
        public Task<List<Product>> GetProductsAsync(bool trackChange) => GetValues(trackChange).ToListAsync();
        


        public async Task<PagedList<Product>> GetProductsAsync(ProductParameters parameters,bool trackChange)
        {
	        var products = await GetValues(trackChange)
		        .FilterProduct(parameters.MinPrice, parameters.MaxPrice)
		        .Search(parameters.SearchTerm)
		        .Sort(parameters.OrderBy)
		        .ToListAsync();
		        
	       return PagedList<Product>
		       .ToPagedList(products,parameters.PageNumber,parameters.PageSize);

        }

        public async Task<Product?> GetOneProductByIdAsync(int id, bool trackChange) => await FindByConditional(b => b.Id.Equals(id), trackChange).SingleOrDefaultAsync();

        public void UpdateOneProduct(Product product)=>
         Update(product);

        
    }
}

