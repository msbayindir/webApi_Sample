﻿using System;
namespace Repositories.Contracts
{
	public interface IRepositoryManager
	{
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}

