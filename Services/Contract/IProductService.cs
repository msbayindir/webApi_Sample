﻿using System;
using Entities.Models;

namespace Services.Contract
{
	public interface IProductService
	{
        IQueryable<Product> GetProducts(bool trackChange);
        Product GetOneProductById(int id, bool trackChange);
        Product CreateOneProduct(Product product);
        void UpdateOneProduct(int id,Product product,bool trackChange);
        void DeleteOneProduct(int id,bool trackChange);
    }
}

