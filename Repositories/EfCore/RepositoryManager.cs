using System;
using Repositories.Contracts;

namespace Repositories.EfCore
{
	public class RepositoryManager:IRepositoryManager
	{
        private readonly RepositoryContext context;
        private readonly IProductRepository repository;

        public RepositoryManager(RepositoryContext context, IProductRepository repository)
        {
            this.context = context;
            this.repository = repository;

        }

        public IProductRepository Product => repository;

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

