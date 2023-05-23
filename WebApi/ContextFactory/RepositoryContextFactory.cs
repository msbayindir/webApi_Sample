using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace WebApi.ContextFactory
{
	public class RepositoryContextFactory:IDesignTimeDbContextFactory<RepositoryContext>
	{
		public RepositoryContextFactory()
		{
		}

        public RepositoryContext CreateDbContext(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(conf.GetConnectionString("sql"), b => b.MigrationsAssembly("WebApi"));

            return new RepositoryContext(builder.Options);
        }
    }
}

