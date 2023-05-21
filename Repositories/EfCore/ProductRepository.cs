using System;
using Entities.Models;
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


        public IQueryable<Product> GetProducts(bool trackChange) => GetValues(trackChange);
      

        public IQueryable<Product> GetOneProductById(int id, bool trackChange) =>
            FindByConditional(b => b.Id.Equals(id), trackChange);


        public void UpdateOneProduct(Product product)=>
         Update(product);
    }
}

