using System;
using Services.Contract;

namespace Services
{
	public class ServiceManager:IServiceManager
	{
		private readonly IProductService _productService;

        public ServiceManager(IProductService productService)
        {
            _productService = productService;
        }


        public IProductService productService => _productService;
    }
}

