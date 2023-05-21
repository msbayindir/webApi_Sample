using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EfCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
             new Product { Id = 1, Price = 12, ProductName = "Pc" },
             new Product { Id = 2, Price = 16, ProductName = "Laptop" },
             new Product { Id = 3, Price = 20, ProductName = "Car" }
             );



        }
    }
}

