using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EfCore;
using Services.Contract;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/product")]
	public class ProductController:ControllerBase
	{
		private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            this._manager = manager;
        }

   

		[HttpGet]
		public IActionResult GetProducts()
		{
            
			return Ok(_manager.productService.GetProducts(false));
		}
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute(Name ="id")]int id)
        {
            return Ok(_manager.productService.GetOneProductById(id,false));
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            _manager.productService.CreateOneProduct(product);
            return StatusCode(201,product);
        }
    }
}

