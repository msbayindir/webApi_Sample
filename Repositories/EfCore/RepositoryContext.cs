using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EfCore.Config;

namespace Repositories.EfCore
{
	public class RepositoryContext:DbContext
	{
		public DbSet<Product> Products { get; set; }
		public RepositoryContext(DbContextOptions options):base(options)
		{

		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}

